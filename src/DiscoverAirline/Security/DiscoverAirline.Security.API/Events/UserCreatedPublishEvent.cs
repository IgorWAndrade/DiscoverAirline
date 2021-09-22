using DiscoverAirline.CoreBroker;
using DiscoverAirline.Security.API.Models.Request;
using Newtonsoft.Json;

namespace DiscoverAirline.Security.API.Events
{
    public class UserCreatedEvent
    {
        public UserCreatedEvent(string userId, string userName, UserAddressRequest address)
        {
            UserId = userId;
            UserName = userName;
            Address = address;
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public UserAddressRequest Address { get; set; }

        public static MessageBody Create(string to, string from, UserCreatedEvent @event)
        {
            var body = JsonConvert.SerializeObject(@event);
            return BuilderMessage.Created(to, from, body);
        }
    }
}
