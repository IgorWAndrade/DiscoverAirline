using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<Role> _roleRepository;

        public RoleService(IBaseRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Notification> AddAsync(object model)
        {
            var domain = Role.ToCreatedFromClass(model);
            await _roleRepository.AddAsync(domain);

            return Notification.Create(domain.Id);
        }

        public async Task<Notification> GetAsync()
        {
            var roles = await _roleRepository.GetAsync();
            return Notification.Create(roles.Select(x => x.Name));
        }
    }
}
