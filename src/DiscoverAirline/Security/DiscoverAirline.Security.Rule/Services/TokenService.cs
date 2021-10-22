using DiscoverAirline.Core;
using DiscoverAirline.CoreAPI.Settings;
using DiscoverAirline.CoreAPI.Utils;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Domain.ValueObjects;
using DiscoverAirline.Security.Rule.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class TokenService : ITokenService
    {
        private readonly SecuritySettings _securitySettings;
        private readonly SecurityContext _securityContext;
        private readonly IBaseRepository<UserRefreshToken> _userRefreshTokenRepository;

        public TokenService(
            IConfiguration configuration,
            SecurityContext securityContext,
            IBaseRepository<UserRefreshToken> userRefreshTokenRepository)
        {
            _securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
            _securityContext = securityContext;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<Token> GenerateTokenAsync(User user)
        {
            var token = await CreateTokenAsync(user);
            var tokenRefresh = CreateTokenRefresh(user);

            await AddRefreshTokenAsync(user.Id, tokenRefresh);
            return Token.Generate(user, tokenRefresh, token.Value, token.Key.ValidTo, token.Key.ValidFrom);
        }

        public async Task<int> GetRefreshTokenByToken(string userRefresh)
        {
            var notification = Notification.Create();
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var storedRefreshToken = await _userRefreshTokenRepository.FirstAsync(x => x.Token.Equals(userRefresh));
            if (storedRefreshToken == null)
                notification.AddError("Não existe um Token de Atualização para este Usuario");

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                notification.AddError("Token de Atualização expirado, usuario precisa logar novamente.");

            return storedRefreshToken.UserId;
        }

        #region Method Privates

        private async Task<KeyValuePair<SecurityToken, string>> CreateTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var subject = await CreateSubjectAsync(user);
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

        private async Task<ClaimsIdentity> CreateSubjectAsync(User user)
        {
            var result = new ClaimsIdentity();
            var profile = await CreateProfileAsync(user);

            result.AddClaim(new Claim("Id", user.Id.ToString()));
            result.AddClaim(new Claim("Security", profile));
            result.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            result.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, user.Email));
            result.AddClaim(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            result.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            return await Task.FromResult(result);
        }

        private async Task<string> CreateProfileAsync(User user)
        {
            var profileSecurity = new ProfileSecurity(user.Email);

            if (user.RoleId.HasValue)
            {
                profileSecurity.Name = user.Role.Name;

                var auths = await _securityContext.Authorizations
                    .Include(x => x.Application)
                    .Include(x => x.Access)
                    .Include(x => x.Actions)
                    .Where(x => x.RoleId == user.RoleId).ToListAsync();

                foreach (var auth in auths)
                {
                    SetProfile(auth, profileSecurity);
                }
            }

            return CodificationUtil.Base64Encode(profileSecurity);
        }

        private void SetProfile(Authorization auth, ProfileSecurity profileSecurity)
        {
            var service = profileSecurity.Services.FirstOrDefault(x => x.Id == auth.ApplicationId);

            if (service == null)
            {
                var serviceNew = new ServiceSecurity(auth.Application.Id, auth.Application.Name);
                var controller = new ControllerSecurity(auth.Access.Id, auth.Access.Name);
                var actions = auth.Actions;

                controller.Actions.AddRange(actions.Select(x => x.Name).ToList());
                serviceNew.Controllers.Add(controller);

                profileSecurity.Services.Add(serviceNew);
            }
            else
            {
                var controller = new ControllerSecurity(auth.Access.Id, auth.Access.Name);
                var actions = auth.Actions;

                controller.Actions.AddRange(actions.Select(x => x.Name).ToList());
                service.Controllers.Add(controller);

                profileSecurity.Services.Remove(service);
                profileSecurity.Services.Add(service);
            }
        }

        private UserRefreshToken CreateTokenRefresh(User user)
        {
            return new UserRefreshToken()
            {
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(1),
                Token = UserRefreshToken.GenerateToken()
            };
        }

        private async Task AddRefreshTokenAsync(int userId, UserRefreshToken tokenRefresh)
        {
            var refreshToken = await _userRefreshTokenRepository.FirstAsync(x => x.UserId == userId);
            if (refreshToken != null)
            {
                await _userRefreshTokenRepository.DeleteAsync(refreshToken.Id);
            }
            await _userRefreshTokenRepository.AddAsync(tokenRefresh);
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        #endregion
    }
}
