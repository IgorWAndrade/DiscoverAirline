using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Notification> GetFullAsync(string userName)
        {
            return Notification.Create(await _userRepository.GetFullAsync(userName));
        } 

        public async Task<Notification> AddAsync(object userRequest)
        {
            var user = User.ToRegisterFromClass(userRequest);
            var valid = User.Valid(user);
            var existsUser = await _repositorio.AnyAsync(x => x.Email == user.Email);

            if (valid && !existsUser)
            {
                var userRepo = await _userRepository.AddAsync(user);

                return Notification.Create(userRepo);
            }
            else
                return null;
        }

        public async Task<Notification> LoginAsync(string userName, string userPassword)
        {
            var hash = User.ToPasswordHash(userPassword);
            return Notification.Create(await _userRepository.FirstFullAsync(x => x.Email.Equals(userName) && x.PasswordHash.Equals(hash)));
        }

    }
}
