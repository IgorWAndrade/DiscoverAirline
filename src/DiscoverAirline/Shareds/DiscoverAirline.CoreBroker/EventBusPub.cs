using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.CoreBroker.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace DiscoverAirline.CoreBroker
{
    public class EventBusPub : EventBus, IEventBusPub
    {
        private const string BROKER_NAME = "discoverairline_event_bus";

        public void Publish(IntegrationEvent @event)
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            using (var _channel = CreateModel())
            {
                var eventName = @event.GetType().Name;
                var jsonMessage = JsonSerializer.Serialize(@event, @event.GetType());
                var body = Encoding.UTF8.GetBytes(jsonMessage);
                var queue = CreateQueueName(BROKER_NAME, eventName);

                _channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                _channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
            }
        }
    }
}
