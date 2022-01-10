using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.Applications;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IBaseRepository<Application> _repository;

        public ApplicationService(IBaseRepository<Application> repository)
        {
            _repository = repository;
        }

        public async Task<Notification> AddAsync(object model)
        {
            var request = (ApplicationCreateRequest)model;
            var domain = new Application
            {
                Name = request.Name
            };
            await _repository.AddAsync(domain);

            return Notification.Create(domain.Id);
        }

        public async Task<Notification> UpdateAsync(object model)
        {
            var request = (ApplicationUpdateRequest)model;
            var domain = await _repository.GetByIdAsync(request.Id);
            domain.Name = request.Name;

            await _repository.UpdateAsync(domain);
            return Notification.Create(request);
        }

        public async Task<Notification> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return Notification.Create(result);
        }

        public async Task<Notification> GetAsync() => Notification.Create(await _repository.GetAsync());
    }
}
