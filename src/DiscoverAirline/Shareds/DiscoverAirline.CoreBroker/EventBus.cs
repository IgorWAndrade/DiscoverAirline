using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.CoreBroker.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace DiscoverAirline.CoreBroker
{
    public class EventBus : IEventBus
    {
        private IModel _channel;
        private IConnection _connection;
        private IConnectionFactory _connectionFactory;

        private const string BROKER_NAME = "discoverairline_event_bus";

        public EventBus()
        {
            TryConnect();
        }

        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen;
            }
        }

        public void TryConnect()
        {
            if (_connectionFactory == null)
            {
                _connectionFactory = new ConnectionFactory()
                {
                    DispatchConsumersAsync = true
                };
            }

            _connection = _connectionFactory
                  .CreateConnection();

            if (IsConnected)
            {
                Console.WriteLine($"Message Broker {IsConnected}");
            }
            else
            {
                Console.WriteLine($"Message Broker {IsConnected}");
            }
        }

        public Task PublishAsync<T>(string queueDeclare, T message) where T : IntegrationEvent
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            var _channel = CreateModel();
            var queue = CreateQueueName(BROKER_NAME, queueDeclare);
            var body = IntegrationEvent.ToByte(message);

            _channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);

            return Task.CompletedTask;
        }

        public Task SubscribeAsync<T>(string queueDeclare, Func<string, Task> action)
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            var _channel = CreateModel();

            var queue = CreateQueueName(BROKER_NAME, queueDeclare);

            _channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += async (ch, ea) =>
            {
                var bytes = ea.Body.ToArray();

                var body = IntegrationEvent.ToJson(bytes);

                await action.Invoke(body);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(queue, autoAck: false, consumer: consumer);


            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _connectionFactory = null;
            _connection.Dispose();
        }

        private IModel CreateModel()
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            if (_channel == null)
            {
                _channel = _connection.CreateModel();
            }

            return _channel;
        }

        private string CreateQueueName(string brokerName, string eventName) => $"{brokerName}:{eventName}";
    }
}
