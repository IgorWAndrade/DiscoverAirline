using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Data.Repositories;
using DiscoverAirline.Security.Rule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Security.API.Extensions
{
    public static class InjectorDependenciesExtension
    {

        public static IServiceCollection InjectorDependenciesServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
