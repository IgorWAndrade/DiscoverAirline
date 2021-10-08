using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.CoreBroker.Events;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Services
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(IntegrationEvent integrationEvent);
    }
}
