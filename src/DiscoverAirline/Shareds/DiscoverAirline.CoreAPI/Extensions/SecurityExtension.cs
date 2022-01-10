using DiscoverAirline.CoreAPI.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace DiscoverAirline.CoreAPI.Extensions
{
    public static class SecurityExtension
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
            var key = Encoding.ASCII.GetBytes(securitySettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = securitySettings.Issuer,
                    ValidAudience = securitySettings.Audience,
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            return services;
        }

        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }

        public static TokenValidationParameters ValidationParameters(IConfiguration configuration)
        {
            var securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
            var key = Encoding.ASCII.GetBytes(securitySettings.Secret);

            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = securitySettings.Issuer,
                ValidAudience = securitySettings.Audience,
                RequireExpirationTime = false,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        }
    }
}
