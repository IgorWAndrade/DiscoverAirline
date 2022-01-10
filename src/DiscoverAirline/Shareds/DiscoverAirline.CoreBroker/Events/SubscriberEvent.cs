using DiscoverAirline.CoreBroker.Abstractions;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoverAirline.CoreBroker.Events
{
    public abstract class SubscriberEvent<T> : BackgroundService where T : IntegrationEvent
    {
        protected readonly IEventBus _bus;
        protected readonly IServiceProvider _serviceProvider;
        protected string _subscriptionId;

        protected SubscriberEvent(IEventBus bus, IServiceProvider serviceProvider, string subscriptionId)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
            _subscriptionId = subscriptionId;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.SubscribeAsync<T>(_subscriptionId, async request => await ProcessEvent(request));

            return Task.CompletedTask;
        }

        public abstract Task ProcessEvent(string request);
    }
}
