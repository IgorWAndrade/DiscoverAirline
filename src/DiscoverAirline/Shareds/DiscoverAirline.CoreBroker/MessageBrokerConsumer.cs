using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoverAirline.CoreBroker
{
    public class MessageBrokerConsumer : MessageBroker, IMessageBrokerConsumer
    {
        protected IModel Channel;
        protected string Queue;

        public MessageBrokerConsumer(string queue)
        {
            SetConnect();
            PrepareSubscriber(queue);
            Queue = queue;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonConvert.DeserializeObject<MessageBody>(contentString);

                Console.WriteLine(message);
            };

            Channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Channel.Dispose();
            return Task.CompletedTask;
        }

        public void PrepareSubscriber(string queue)
        {
            var con = Factory.CreateConnection();
            Channel = con.CreateModel();
            Channel.QueueDeclare(queue, true, false, false, null);
        }
    }
}
