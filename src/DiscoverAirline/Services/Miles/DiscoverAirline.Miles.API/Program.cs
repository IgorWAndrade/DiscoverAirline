using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace DiscoverAirline.Miles.API
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
                     webBuilder.UseSerilog();
                 })
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var env = hostingContext.HostingEnvironment;

                 var settingPath = Path.GetFullPath(Path.Combine(@"../../Shareds/DiscoverAirline.CoreAPI/sharedappsettings.json"));

                 config
                     .AddJsonFile(Path.Combine(settingPath), optional: false)
                     .AddJsonFile("appsettings.json", optional: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                 config.AddEnvironmentVariables();
             });
    }
}
