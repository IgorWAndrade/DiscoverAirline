using DiscoverAirline.CoreBroker.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace DiscoverAirline.CoreBroker.Extensions
{
    public static class MessageBusExtension
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                return new EventBus();
            });

            return services;
        }
    }
}
