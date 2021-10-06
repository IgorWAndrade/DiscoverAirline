using DiscoverAirline.CoreBroker.Events;

namespace DiscoverAirline.CoreBroker.Abstractions
{
    public interface IEventBusPub
    {
        void Publish(IntegrationEvent @event);
    }
}
