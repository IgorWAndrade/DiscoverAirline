using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DiscoverAirline.CoreAPI.Extensions
{
    public static class ServiceDiscoveryExtension
    {
        public static IServiceCollection AddServiceDiscovery(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration.GetValue<string>("Consul:Uri");
                consulConfig.Address = new Uri(address);
            }));

            return services;
        }

        public static IApplicationBuilder UseServiceDiscovery(this IApplicationBuilder app, IConfiguration configuration                            )
        {
            var serviceId = configuration["Consul:ServiceId"];
            var serviceName = configuration["Consul:ServiceName"];
            var address = configuration["Consul:Uri"];
            var port = int.Parse(configuration["Consul:Port"]);

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var Iconfig = scope.ServiceProvider.GetService<IConfiguration>();

                string consulServiceID = $"{serviceName}:{serviceId}";

                var client = scope.ServiceProvider.GetService<IConsulClient>();

                var consulServiceRistration = new AgentServiceRegistration
                {
                    Name = serviceName,
                    ID = consulServiceID,
                    Address = address,
                    Port = port
                };

                client.Agent.ServiceRegister(consulServiceRistration);
            }

            return app;
        }
    }
}
