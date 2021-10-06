using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.CoreBroker.Events;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Events
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(IntegrationEvent integrationEvent);
    }
}
