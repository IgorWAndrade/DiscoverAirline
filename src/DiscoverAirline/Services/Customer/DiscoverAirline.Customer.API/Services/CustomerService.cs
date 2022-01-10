using DiscoverAirline.CoreBroker.Events;
using System;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Services
{
    public class CustomerService : ICustomerService
    {
        public Task AddCustomerAsync(IntegrationEvent integrationEvent)
        {
            Console.WriteLine(integrationEvent);
            return Task.CompletedTask;
        }
    }
}
