using DiscoverAirline.CoreBroker;
using DiscoverAirline.CoreBroker.Events;
using DiscoverAirline.Customer.API.Events.EventsIntegrations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Events.EventsHandles
{
    public class CustomerAddressReceived : EventBusSub
    {
        private const string BROKER_NAME = "discoverairline_event_bus";
        private const string EVENT_NAME = "UserCreatedEvent";
        private string QUEUE = "";

        private readonly IModel _channel;
        private readonly IServiceProvider _service;

        public CustomerAddressReceived(
            IServiceProvider serviceProvider,
            IMemoryCache memoryCache
            )
        {
            _channel = CreateModel();
            _service = serviceProvider;
            QUEUE = CreateQueueName(BROKER_NAME, EVENT_NAME);
        }

        public override async Task Handler(IntegrationEvent integrationEvent)
        {
            using (var scope = _service.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<ICustomerService>();

                await service.AddCustomerAsync(integrationEvent);
            }
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;
            _channel.BasicConsume(
                queue: QUEUE,
                autoAck: false,
                consumer: consumer);

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            return Task.CompletedTask;
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var message = Encoding.UTF8.GetString(@event.Body.Span);
            var body = JsonSerializer.Deserialize<CustomerReceived>(message);
            try
            {
                await Handler(body);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            _channel.BasicAck(@event.DeliveryTag, multiple: false);
        }
    }
}
