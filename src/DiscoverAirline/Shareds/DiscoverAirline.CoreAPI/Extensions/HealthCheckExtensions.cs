using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.CoreAPI.Extensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheckServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var name = configuration["Name"];

            services.AddHealthChecks();

            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5);
                options.MaximumHistoryEntriesPerEndpoint(10);
                options.AddHealthCheckEndpoint($"DiscoverAirline - {name} - Serviço Health Checks", "/health");
            })
.AddInMemoryStorage();

            return services;
        }

        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });

            return app;
        }
    }
}
