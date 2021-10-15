using DiscoverAirline.CoreAPI.Extensions;
using DiscoverAirline.CoreBroker.Extensions;
using DiscoverAirline.Security.API.Application.Extensions;
using DiscoverAirline.Security.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Security.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseServices(Configuration);

            services.InjectorDependenciesServices();

            services.AddApiServices(Configuration);

            services.AddDocumentationServices(Configuration);

            services.AddLogServices(Configuration);

            services.AddServiceDiscovery(Configuration);
            
            services.AddEventBusService(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDocumentation(env);

            app.UseApi(env);

            app.UseServiceDiscovery(Configuration);
        }

    }
}
