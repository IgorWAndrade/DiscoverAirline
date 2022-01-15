using DiscoverAirline.Security.API.Application.Services;
using DiscoverAirline.Security.API.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Security.API.Extensions
{
    public static class InjectorDependenciesExtension
    {
        public static IServiceCollection InjectorDependenciesServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }

}
