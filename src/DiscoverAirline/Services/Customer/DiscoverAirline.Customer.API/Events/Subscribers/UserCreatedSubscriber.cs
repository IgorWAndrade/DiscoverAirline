using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.Customer.API.Events.EventsIntegrations;
using DiscoverAirline.Customer.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Events.Subscribers
{
    public class UserCreatedSubscriber : SubscriberEvent<CustomerReceived>
    {
        public UserCreatedSubscriber(IEventBus bus, IServiceProvider serviceProvider) : base(bus, serviceProvider, "UserCreatedEvent") { }

        public override async Task ProcessEvent(string request)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ICustomerService>();

                var customerAddressReceived = JsonConvert.DeserializeObject<CustomerReceived>(request);

                await context.AddCustomerAsync(customerAddressReceived);
            }
        }
    }

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
