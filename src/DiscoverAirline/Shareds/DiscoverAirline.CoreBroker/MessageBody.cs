using System;

namespace DiscoverAirline.CoreBroker
{
    public class MessageBody
    {
        public MessageBody(string to, string from, string body)
        {
            To = to;
            From = from;
            Body = body;
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; }

    }

    public static class BuilderMessage
    {
        public static MessageBody Created(string to, string from, string body)
        {
            return new MessageBody(to, from, body);
        }
    }
}
