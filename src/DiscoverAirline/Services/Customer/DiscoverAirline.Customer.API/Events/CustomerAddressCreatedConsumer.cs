using DiscoverAirline.CoreBroker;

namespace DiscoverAirline.Customer.API.Events
{
    public class CustomerAddressCreatedConsumer : MessageBrokerConsumer
    {
        public CustomerAddressCreatedConsumer(string queue = "UserCreated_SecurityService") : base(queue)
        {
        }
    }
}
