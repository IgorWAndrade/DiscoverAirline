using DiscoverAirline.Trip.API.Domain.Commands.Requests;
using DiscoverAirline.Trip.API.Domain.Commands.Responses;
using System;

namespace DiscoverAirline.Trip.API.Domain.Handlers
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        public CreateCustomerResponse Handle(CreateCustomerRequest command)
        {
            return new CreateCustomerResponse
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email
            };
        }

    }
}
