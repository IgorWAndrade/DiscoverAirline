using DiscoverAirline.CoreBroker.Events;
using System;
using System.Threading.Tasks;

namespace DiscoverAirline.CoreBroker.Abstractions
{
    public interface IEventBus
    {
        void TryConnect();
        Task PublishAsync<T>(string queue, T message) where T : IntegrationEvent;
        Task SubscribeAsync<T>(string queue, Func<string, Task> action);
    }
}
