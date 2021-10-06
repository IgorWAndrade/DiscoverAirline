using RabbitMQ.Client;

namespace DiscoverAirline.CoreBroker.Abstractions
{
    public interface IEventBus
    {
        IModel CreateModel();
        string CreateQueueName(string brokerName, string eventName);
    }
}
