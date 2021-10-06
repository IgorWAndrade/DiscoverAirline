using DiscoverAirline.CoreBroker.Events;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DiscoverAirline.Customer.API.Events.EventsIntegrations
{
    public class CustomerReceived : IntegrationEvent
    {
        public CustomerReceived(string to, string from) : base(to, from)
        {
        }

        [JsonInclude]
        public CustomerAddress Address { get; set; }
    }

    public class CustomerAddress
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string District { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ZipCode { get; set; }
    }
}
