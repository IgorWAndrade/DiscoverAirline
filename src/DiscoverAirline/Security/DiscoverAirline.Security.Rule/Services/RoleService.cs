using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.Role;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<Role> _roleRepository;
        private readonly IBaseRepository<User> _userRepository;

        public RoleService(
            IBaseRepository<Role> roleRepository,
            IBaseRepository<User> userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<Notification> AddAsync(object model)
        {
            var request = (RoleCreateRequest)model;
            var domain = new Role
            {
                Name = request.Name,
                BusinessName = request.BusinessName
            };
            await _roleRepository.AddAsync(domain);

            return Notification.Create(domain.Id);
        }

        public async Task<Notification> AttachUsersAsync(object model)
        {
            var request = (RoleAttachUsersRequest)model;

            var role = await _roleRepository.GetByIdAsync(request.RoleId);
            if (role != null)
            {
                foreach (var userId in request.Users)
                {
                    var user = await _userRepository.GetByIdAsync(userId);
                    user.RoleId = role.Id;

                    await _userRepository.UpdateAsync(user);
                }

                return Notification.Create(true);
            }
            return Notification.Create(false);
        }

        public async Task<Notification> UpdateAsync(object model)
        {
            var request = (RoleUpdateRequest)model;

            var domain = await _roleRepository.GetByIdAsync(request.Id);
            domain.Name = request.Name;
            domain.BusinessName = request.BusinessName;

            await _roleRepository.UpdateAsync(domain);
            return Notification.Create(request);
        }

        public async Task<Notification> DeleteAsync(int id)
        {
            var result = await _roleRepository.DeleteAsync(id);
            return Notification.Create(result);
        }

        public async Task<Notification> DetachUsersAsync(object model)
        {
            var request = (RoleDetachUsersRequest)model;

            foreach (var userId in request.Users)
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user.RoleId == request.RoleId)
                {
                    user.RoleId = null;
                }

                await _userRepository.UpdateAsync(user);
            }
            return Notification.Create(true);
        }

        public async Task<Notification> GetAsync() => Notification.Create(await _roleRepository.GetAsync());

    }
}
