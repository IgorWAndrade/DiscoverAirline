using Microsoft.Extensions.Hosting;

namespace DiscoverAirline.CoreBroker
{
    public interface IMessageBrokerConsumer : IMessageBroker, IHostedService
    {
        void PrepareSubscriber(string queue);
    }
}
