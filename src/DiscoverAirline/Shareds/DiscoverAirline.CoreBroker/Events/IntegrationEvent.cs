using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscoverAirline.CoreBroker.Events
{
    public class IntegrationEvent
    {
        [JsonConstructor]
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        [JsonInclude]
        public Guid Id { get; private init; }

        [JsonInclude]
        public DateTime CreationDate { get; private init; }

        public static string ToJson(byte[] bodyBytes)
        {
            return System.Text.Encoding.UTF8.GetString(bodyBytes);
        }

        public static byte[] ToByte<T>(T message) where T : IntegrationEvent
        {
            var jsonMessage = JsonSerializer.Serialize(message, message.GetType());
            return Encoding.UTF8.GetBytes(jsonMessage);
        }
    }
}
