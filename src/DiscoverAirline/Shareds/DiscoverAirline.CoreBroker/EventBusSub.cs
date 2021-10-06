using DiscoverAirline.CoreBroker.Events;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoverAirline.CoreBroker
{
    public abstract class EventBusSub : EventBus, IHostedService
    {
        public abstract Task Handler(IntegrationEvent integrationEvent);
        public abstract Task StartAsync(CancellationToken cancellationToken);
        public abstract Task StopAsync(CancellationToken cancellationToken);
    }
}
