using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace DiscoverAirline.CoreBroker
{
    public class MessageBrokerPublish : MessageBroker, IMessageBrokerPublish
    {
        public bool Publish(string queue, MessageBody message)
        {
            try
            {
                using (var con = Factory.CreateConnection())
                {
                    using (var channel = con.CreateModel())
                    {
                        channel.QueueDeclare(
                            queue: queue,
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
                            );

                        var objBody = JsonConvert.SerializeObject(message);
                        var bytesBody = Encoding.UTF8.GetBytes(objBody);

                        channel.BasicPublish(
                            exchange: "",
                            routingKey: queue,
                            basicProperties: null,
                            body: bytesBody);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
