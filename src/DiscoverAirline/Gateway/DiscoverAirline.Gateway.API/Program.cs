using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DiscoverAirline.Gateway.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                var settingPath = Path.GetFullPath(Path.Combine(@"../../Shareds/DiscoverAirline.CoreAPI/sharedappsettings.json"));

                config
                    .AddJsonFile(Path.Combine(settingPath), optional: false)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

                config.AddEnvironmentVariables();
            });
    }
}
