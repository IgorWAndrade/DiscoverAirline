using DiscoverAirline.CoreBroker;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Security.API.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IMessageBrokerPublish, MessageBrokerPublish>();

            return services;
        }
    }
}
