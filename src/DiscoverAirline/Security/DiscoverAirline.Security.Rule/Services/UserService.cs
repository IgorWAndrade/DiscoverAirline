using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IBaseRepository<Profile> _profileRepository;

        public UserService(
            IBaseRepository<User> repositorio,
            IBaseRepository<Profile> profileRepository) : base(repositorio)
        {
            _profileRepository = profileRepository;
        }

        public async Task<User> AddAsync(object userRequest)
        {
            var user = User.ToRegisterFromClass(userRequest);
            var valid = User.Valid(user);
            var existsUser = await _repositorio.AnyAsync(x => x.Email == user.Email);

            if (valid && !existsUser)
            {
                var userRepo = await _repositorio.AddAsync(user);
                await _profileRepository.AddAsync(new Profile
                {
                    UserId = userRepo.Id
                });

                return userRepo;
            }
            else
                return null;
        }

        public async Task<User> LoginAsync(string userName, string userPassword)
        {
            var hash = User.ToPasswordHash(userPassword);
            return await _repositorio.FirstAsync(x => x.Email.Equals(userName) && x.PasswordHash.Equals(hash));
        }
    }
}
