namespace DiscoverAirline.CoreBroker
{
    public interface IMessageBrokerPublish : IMessageBroker
    {
        bool Publish(string queue, MessageBody @message);
    }
}
