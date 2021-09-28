using DiscoverAirline.Core;
using DiscoverAirline.CoreAPI.Settings;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SecuritySettings _securitySettings;

        public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
        }



        public async Task<Notification> RefreshAsync(UserLoggedInRequest model)
        {
            var notification = new Notification();

            notification.SetMessage("Refresh in Building");

            return await Task.FromResult(notification);
        }

        public async Task<UserDefaultResponse> GenerateTokenAsync(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var user = await _userManager.FindByNameAsync(email);
            var subject = await CreateSubject(user);
            var key = Encoding.ASCII.GetBytes(_securitySettings.Secret);

            var hoursExpiration = DateTime.UtcNow.AddHours(_securitySettings.ExpirationInHours);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _securitySettings.Issuer,
                Audience = _securitySettings.Audience,
                Subject = subject,
                Expires = hoursExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var tokenStr = tokenHandler.WriteToken(token);

            return new UserDefaultResponse
            {
                AccessToken = string.Format($"Bearer {tokenStr}"),
                RefreshAccessToken = CreateRefreshToken(email),
                Type_Acess = "Bearer",
                ExpiresIn = hoursExpiration
            };
        }

        private RefreshToken CreateRefreshToken(string email)
        {
            var refreshToken = new RefreshToken
            {
                Username = email,
                ExpirationDate = DateTime.UtcNow.AddHours(_securitySettings.ExpirationRefreshInHours)
            };

            string token;
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }

            refreshToken.Token = token.Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);

            return refreshToken;
        }

        private async Task<ClaimsIdentity> CreateSubject(IdentityUser user)
        {
            var result = new ClaimsIdentity();

            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

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
    }
}
