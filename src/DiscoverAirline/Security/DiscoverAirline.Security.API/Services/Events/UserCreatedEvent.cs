using DiscoverAirline.CoreBroker.Events;
using DiscoverAirline.Security.API.Services.Dtos;
using System.Text.Json.Serialization;

namespace DiscoverAirline.Security.API.Services.Events
{
    public class UserCreatedEvent : IntegrationEvent
    {
        public UserCreatedEvent(string to, string from, string userId, string userName, UserAddressRequest address) : base(to, from)
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
        public UserAddressRequest Address { get; set; }
    }
}
