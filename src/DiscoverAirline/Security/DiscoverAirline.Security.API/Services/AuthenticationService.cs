using DiscoverAirline.CoreAPI.Extensions;
using DiscoverAirline.CoreAPI.Settings;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Services.Dtos;
using Microsoft.AspNetCore.Identity;
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

namespace DiscoverAirline.Security.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SecurityDbContext _securityDbContext;
        private readonly SecuritySettings _securitySettings;

        public AuthenticationService(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            SecurityDbContext securityDbContext)
        {
            _userManager = userManager;
            _securityDbContext = securityDbContext;
            _securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
        }

        public async Task<UserDefaultResponse> GenerateTokenAsync(IdentityUser user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var subject = await CreateSubject(user);
                var key = Encoding.ASCII.GetBytes(_securitySettings.Secret);

                var minutesExpiration = DateTime.UtcNow.AddMinutes(_securitySettings.ExpirationInMinutes);

                var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _securitySettings.Issuer,
                    Audience = _securitySettings.Audience,
                    Subject = subject,
                    Expires = minutesExpiration,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                });

                var refreshToken = new RefreshToken()
                {
                    JwtId = token.Id,
                    IsUsed = false,
                    UserId = user.Id,
                    AddedDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddDays(1),
                    IsRevoked = false,
                    Token = RandomString(25) + Guid.NewGuid()
                };

                var userToken = new UserToken
                {
                    Id = user.Id,
                    //Claims = subject.Claims,
                    Email = user.Email
                };

                await _securityDbContext.RefreshTokens.AddAsync(refreshToken);
                await _securityDbContext.SaveChangesAsync();

                var tokenStr = tokenHandler.WriteToken(token);

                return new UserDefaultResponse
                {
                    UsuarioToken = userToken,
                    Success = true,
                    Token = string.Format($"Bearer {tokenStr}"),
                    RefreshToken = refreshToken.Token,
                    Type_Acess = "Bearer",
                    ExpiresIn = minutesExpiration
                };
            }
            catch
            {
                return new UserDefaultResponse
                {
                    Success = false
                };
            }
        }

        public async Task<UserDefaultResponse> RefreshTokenAsync(UserLoggedInRequest tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var userResponse = new UserDefaultResponse();

            try
            {
                var storedRefreshToken = await _securityDbContext.RefreshTokens.FirstOrDefaultAsync(x => x.Token == tokenRequest.RefreshToken);

                if (storedRefreshToken == null)
                {
                    return new UserDefaultResponse()
                    {
                        Errors = new List<string>() { "refresh token doesnt exist" },
                        Success = false
                    };
                }

                // Check the date of the saved token if it has expired
                if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                {
                    return new UserDefaultResponse()
                    {
                        Errors = new List<string>() { "token has expired, user needs to relogin" },
                        Success = false
                    };
                }

                // check if the refresh token has been used
                if (storedRefreshToken.IsUsed)
                {
                    return new UserDefaultResponse()
                    {
                        Errors = new List<string>() { "token has been used" },
                        Success = false
                    };
                }

                // Check if the token is revoked
                if (storedRefreshToken.IsRevoked)
                {
                    return new UserDefaultResponse()
                    {
                        Errors = new List<string>() { "token has been revoked" },
                        Success = false
                    };
                }

                _securityDbContext.RefreshTokens.Update(storedRefreshToken);
                await _securityDbContext.SaveChangesAsync();

                var dbUser = await _userManager.FindByIdAsync(storedRefreshToken.UserId);
                return await GenerateTokenAsync(dbUser);
            }
            catch (Exception ex)
            {
                return new UserDefaultResponse()
                {
                    Errors = new List<string>() { ex.Message },
                    Success = false
                };
            }
        }

        private async Task<ClaimsIdentity> CreateSubject(IdentityUser user)
        {
            var result = new ClaimsIdentity();

            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim("Id", user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var role in roles)
            {
                claims.Add(new Claim("Role", role));
            }

            result.AddClaims(claims);

            return result;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
