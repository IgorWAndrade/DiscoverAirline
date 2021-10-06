using DiscoverAirline.CoreBroker.Abstractions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DiscoverAirline.CoreBroker
{
    public class EventBus : IEventBus
    {
        private IConnection _connection;
        private IConnectionFactory _connectionFactory;

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

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            return _connection.CreateModel();
        }

        public bool TryConnect()
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
                _connection.ConnectionShutdown += OnConnectionShutdown;
                _connection.CallbackException += OnCallbackException;
                _connection.ConnectionBlocked += OnConnectionBlocked;

                return true;
            }
            else
            {
                return false;
            }
        }

        public string CreateQueueName(string brokerName, string eventName) => $"{brokerName}:{eventName}";

        protected void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            //_logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");

            TryConnect();
        }

        protected void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            //_logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");

            TryConnect();
        }

        protected void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            //_logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

            TryConnect();
        }

        public void Dispose()
        {
            _connectionFactory = null;
            _connection.Dispose();
        }
    }
}
