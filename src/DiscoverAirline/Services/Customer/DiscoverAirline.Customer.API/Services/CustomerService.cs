using DiscoverAirline.CoreBroker.Events;
using DiscoverAirline.Customer.API.Events;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Services
{
    public class CustomerService : ICustomerService
    {
        public Task AddCustomerAsync(IntegrationEvent integrationEvent)
        {
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
