using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class AuthenticationService : BaseService<User>, IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IBaseRepository<UserRefreshToken> _userRefreshTokenRepository;

        public AuthenticationService(
            IBaseRepository<User> repositorio,
            IUserService userService,
            ITokenService tokenService,
            IBaseRepository<UserRefreshToken> userRefreshTokenRepository) : base(repositorio)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<Notification> RegisterAsync(object model)
        {
            await _userService.AddAsync(model);
            var userClass = User.ToLoginFromClass(model);
            return await LoginLocalAsync(userClass.Email, userClass.Password);
        }

        public async Task<Notification> LoginAsync(object userRequest)
        {
            try
            {
                var userClass = User.ToLoginFromClass(userRequest);
                var userRepo = await _repositorio.FirstAsync(x => x.PasswordHash == userClass.PasswordHash && x.Email == userClass.Email);
                return await LoginLocalAsync(userRepo.Email, userClass.Password);
            }
            catch (Exception ex)
            {
                return Notification.Create(ex);
            }
        }

        public async Task<Notification> LogoutAsync(string name)
        {
            var user = await _repositorio.FirstAsync(x => x.Email == name);
            var storedRefreshToken = await _userRefreshTokenRepository.FirstAsync(x => x.UserId == user.Id);
            await _userRefreshTokenRepository.DeleteAsync(storedRefreshToken.Id);

            return Notification.Create();
        }

        public async Task<Notification> RefreshTokenAsync(string userRefresh)
        {
            var userId = await _tokenService.GetRefreshTokenByToken(userRefresh);
            var userRepo = await _repositorio.FirstAsync(x => x.Id == userId);

            await LogoutAsync(userRepo.Email);
            return await LoginLocalAsync(userRepo.Email, User.ToPasswordString(userRepo.PasswordHash));
        }

        private async Task<Notification> LoginLocalAsync(string userName, string userPassword)
        {
            var userNotification = await _userService.LoginAsync(userName, userPassword);
            var token = await _tokenService.GenerateTokenAsync(userNotification.GetData() as User);

            return Notification.Create(token);
        }

    }
}
