using RabbitMQ.Client;

namespace DiscoverAirline.CoreBroker
{
    public interface IMessageBroker
    {
        void SetConnect();
        ConnectionFactory GetConnect();
    }
}
