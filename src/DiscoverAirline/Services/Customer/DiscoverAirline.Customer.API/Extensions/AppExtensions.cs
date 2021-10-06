using DiscoverAirline.Customer.API.Events;
using DiscoverAirline.Customer.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoverAirline.Customer.API.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerService, CustomerService>();

            return services;
        }
    }
}
