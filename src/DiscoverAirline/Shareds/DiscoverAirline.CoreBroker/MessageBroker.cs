using RabbitMQ.Client;

namespace DiscoverAirline.CoreBroker
{
    public class MessageBroker : IMessageBroker
    {
        protected ConnectionFactory Factory { get; set; }

        public MessageBroker()
        {
            SetConnect();
        }

        public ConnectionFactory GetConnect()
        {
            if (Factory == null)
                SetConnect();

            return Factory;
        }

        public void SetConnect()
        {
            if (Factory == null)
            {
                Factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };
            }
        }
    }
}
