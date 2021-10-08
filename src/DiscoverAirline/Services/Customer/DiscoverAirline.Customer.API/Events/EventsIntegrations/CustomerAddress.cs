using DiscoverAirline.CoreBroker.Events;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DiscoverAirline.Customer.API.Events.EventsIntegrations
{
    public class CustomerReceived : IntegrationEvent
    {
        [JsonInclude]
        public string UserId { get; set; }

        [JsonInclude]
        public string UserName { get; set; }

        [JsonInclude]
        public CustomerAddress Address { get; set; }
    }

    public class CustomerAddress
    {
        [JsonInclude]
        public string Number { get; set; }

        [JsonInclude]
        public string Street { get; set; }

        [JsonInclude]
        public string District { get; set; }

        [JsonInclude]
        public string City { get; set; }

        [JsonInclude]
        public string ZipCode { get; set; }
    }
}
