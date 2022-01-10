using DiscoverAirline.Security.Rule.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Security.API.Application.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
              .AddDbContext<SecurityContext>(
                  options => options.UseSqlServer(
                      configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
