using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.CoreBroker.Events;
using DiscoverAirline.Customer.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoverAirline.Customer.API.Events.Subscribers
{
    public class UserCreatedSubscriber : BackgroundService
    {
        private readonly IEventBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public UserCreatedSubscriber(
            IEventBus bus,
            IServiceProvider serviceProvider
            )
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.SubscribeAsync<CustomerReceived>("UserCreatedEvent", async request => await AddCustomerAsync(request));

            return Task.CompletedTask;
        }

        private async Task AddCustomerAsync(string request)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ICustomerService>();

                var customerAddressReceived = JsonConvert.DeserializeObject<CustomerReceived>(request);

                await context.AddCustomerAsync(customerAddressReceived);
            }
        }
    }

    class CustomerReceived : IntegrationEvent
    {
        [JsonInclude]
        public string UserId { get; set; }
        [JsonInclude]
        public string UserName { get; set; }
        [JsonInclude]
        public CustomerAddress Address { get; set; }
    }

    class CustomerAddress
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
