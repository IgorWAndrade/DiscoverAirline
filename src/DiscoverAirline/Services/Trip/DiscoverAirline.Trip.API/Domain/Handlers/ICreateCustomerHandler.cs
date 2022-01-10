using DiscoverAirline.Trip.API.Domain.Commands.Requests;
using DiscoverAirline.Trip.API.Domain.Commands.Responses;

namespace DiscoverAirline.Trip.API.Domain.Handlers
{
    public interface ICreateCustomerHandler
    {
        CreateCustomerResponse Handle(CreateCustomerRequest command);
    }
}
