using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class ActService : IActService
    {
        private readonly IBaseRepository<DiscoverAirline.Security.Domain.Entities.Action> _repository;

        public ActService(IBaseRepository<DiscoverAirline.Security.Domain.Entities.Action> repository)
        {
            _repository = repository;
        }

        public async Task<Notification> GetAsync() => Notification.Create(await _repository.GetAsync());
    }
}
