using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Security.API.Application.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
