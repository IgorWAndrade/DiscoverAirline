using DiscoverAirline.CoreAPI.Extensions;
using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.CoreBroker.Events;
using DiscoverAirline.CoreBroker.Extensions;
using DiscoverAirline.Security.API.Application.Extensions;
using DiscoverAirline.Security.API.Services.Events;
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
            services.AddIdentityServices(Configuration);

            services.AddApiServices(Configuration);

            services.AddDocumentationServices(Configuration);

            services.AddAppServices();

            services.AddLogServices(Configuration);

            services.AddEventBusService(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDocumentation(env);

            app.UseAppServices();

            app.UseApi(env);
        }

    }
}
