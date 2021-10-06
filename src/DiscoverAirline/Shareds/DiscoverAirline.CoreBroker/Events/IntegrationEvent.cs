using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscoverAirline.CoreBroker.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent(string to, string from)
        {
            Id = Guid.NewGuid();
            To = to;
            From = from;
            CreationDate = DateTime.Now;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, string to, string from)
        {
            Id = id;
            To = to;
            From = from;
            CreationDate = DateTime.Now;
        }

        [JsonInclude]
        public Guid Id { get; private init; }

        [JsonInclude]
        public string To { get; private init; }

        [JsonInclude]
        public string From { get; private init; }

        [JsonInclude]
        public DateTime CreationDate { get; private init; }

        public string ToJson(dynamic obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj, obj.GetType(), new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
