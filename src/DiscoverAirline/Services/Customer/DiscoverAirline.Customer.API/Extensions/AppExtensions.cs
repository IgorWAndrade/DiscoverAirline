using DiscoverAirline.Customer.API.Events;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Customer.API.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddHostedService<CustomerAddressCreatedConsumer>();

            return services;
        }
    }
}
