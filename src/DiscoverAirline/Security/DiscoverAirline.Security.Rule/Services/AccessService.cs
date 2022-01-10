using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.Access;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class AccessService : IAccessService
    {
        private readonly IBaseRepository<Access> _repository;

        public AccessService(IBaseRepository<Access> repository)
        {
            _repository = repository;
        }
        
        public async Task<Notification> GetAsync() => Notification.Create(await _repository.GetAsync());


        public async Task<Notification> AddAsync(object requestModel)
        {
            var request = (AccessCreateRequest)requestModel;
            var domain = new Access
            {
                Name = request.Name
            };
            await _repository.AddAsync(domain);

            return Notification.Create(domain.Id);
        }

        public async Task<Notification> UpdateAsync(object requestModel)
        {
            var request = (AccessUpdateRequest)requestModel;
            var model = await _repository.GetByIdAsync(request.Id);

            model.Name = request.Name;

            var response = await _repository.UpdateAsync(model);
            return Notification.Create(response);
        }

        public async Task<Notification> DeleteAsync(int id)
        {
            var response = await _repository.DeleteAsync(id);
            return Notification.Create(response);
        }
    }
}
