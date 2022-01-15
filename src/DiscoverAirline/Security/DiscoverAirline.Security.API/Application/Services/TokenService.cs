using DiscoverAirline.Core;
using DiscoverAirline.CoreAPI.Settings;
using DiscoverAirline.Security.API.Application.Services.Interfaces;
using DiscoverAirline.Security.API.Application.ViewModels;
using DiscoverAirline.Security.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly SecuritySettings _securitySettings;
        private readonly ApplicationDbContext _applicationDbContext;

        public TokenService(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UsuarioToken> GenerateTokenAsync(IdentityUser user, IList<string> roles, ICollection<Claim> claims)
        {
            var tokenRefresh = CreateTokenRefresh(user);
            var token = CreateToken(user, roles, claims, tokenRefresh.Token);

            await SetRefreshTokenAsync(user.Id, tokenRefresh);
            return UsuarioToken.Generate(user, tokenRefresh, token.Value, token.Key.ValidTo, token.Key.ValidFrom);
        }

        public async Task<string> GetRefreshTokenByToken(string userRefresh)
        {
            var notification = Notification.Create();
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var storedRefreshToken = await _applicationDbContext.AspNetUsersRefreshTokens.FirstAsync(x => x.Token.Equals(userRefresh));
            if (storedRefreshToken == null)
                notification.AddError("Não existe um Token de Atualização para este Usuario");

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                notification.AddError("Token de Atualização expirado, usuario precisa logar novamente.");

            return storedRefreshToken.UserId;
        }

        #region Method Privates

        private KeyValuePair<SecurityToken, string> CreateToken(IdentityUser user, IList<string> roles, ICollection<Claim> claims, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var subject = CreateSubject(user.Id, user.Email, roles, claims, token);
            var key = Encoding.ASCII.GetBytes(_securitySettings.Secret);
            var minutesExpiration = DateTime.UtcNow.AddMinutes(_securitySettings.ExpirationInMinutes);

            var keyToken = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _securitySettings.Issuer,
                Audience = _securitySettings.Audience,
                Subject = subject,
                Expires = minutesExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return new KeyValuePair<SecurityToken, string>(keyToken, tokenHandler.WriteToken(keyToken));
        }

        private ClaimsIdentity CreateSubject(string id, string email, IList<string> roles, ICollection<Claim> claims, string token)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            claims.Add(new Claim("RefreshToken", token));
            foreach (var userRole in roles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private UserRefreshToken CreateTokenRefresh(IdentityUser user)
        {
            return new UserRefreshToken()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(1),
                Token = UserRefreshToken.GenerateToken()
            };
        }

        private async Task SetRefreshTokenAsync(string userId, UserRefreshToken tokenRefresh)
        {
            var refreshToken = await _applicationDbContext.AspNetUsersRefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);

            if (refreshToken != null)
            {
                _applicationDbContext.AspNetUsersRefreshTokens.Remove(refreshToken);
            }

            await _applicationDbContext.AspNetUsersRefreshTokens.AddAsync(tokenRefresh);
            await _applicationDbContext.SaveChangesAsync();
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        #endregion
    }
}
