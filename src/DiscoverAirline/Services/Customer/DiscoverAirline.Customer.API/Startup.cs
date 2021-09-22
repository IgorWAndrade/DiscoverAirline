using DiscoverAirline.CoreAPI.Extensions;
using DiscoverAirline.CoreAPI.Settings;
using DiscoverAirline.Customer.API.Events;
using DiscoverAirline.Customer.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Customer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiServices(Configuration);

            services.AddDocumentationServices(Configuration);

            services.AddAppService();

            services.AddLogServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDocumentation(env);

            app.UseApi(env);
        }
    }
}
