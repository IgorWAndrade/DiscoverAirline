using DiscoverAirline.CoreBroker.Events;
using System.Text.Json.Serialization;

namespace DiscoverAirline.Security.Rule.Events.Integrations
{
    public class UserCreatedIntegration : IntegrationEvent
    {
        public UserCreatedIntegration(string userId, string userName, UserAddress address)
        {
            UserId = userId;
            UserName = userName;
            Address = address;
        }

        [JsonInclude]
        public string UserId { get; set; }

        [JsonInclude]
        public string UserName { get; set; }

        [JsonInclude]
        public UserAddress Address { get; set; }
    }

    public class UserAddress
    {
        public string Number { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}
