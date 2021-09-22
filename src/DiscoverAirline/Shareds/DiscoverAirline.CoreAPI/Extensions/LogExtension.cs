using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace DiscoverAirline.CoreAPI.Extensions
{
    public static class LogExtension
    {
        public static IServiceCollection AddLogServices(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Seq(configuration["Seq:Uri"])
                .CreateLogger();

            return services.AddSingleton(Log.Logger);
        }
    }
}
