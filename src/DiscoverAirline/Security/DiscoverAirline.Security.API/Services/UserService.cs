using DiscoverAirline.Core;
using DiscoverAirline.CoreBroker;
using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Services.Dtos;
using DiscoverAirline.Security.API.Services.Events;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolerManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventBus _eventBus;

        public UserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> rolerManager,
            SignInManager<IdentityUser> signInManager,
            IAuthenticationService authenticationService,
            IEventBus eventBus)
        {
            _userManager = userManager;
            _rolerManager = rolerManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _eventBus = eventBus;
        }

        public async Task<Notification> CreateAsync(UserRegisterRequest model)
        {
            var notification = new Notification();

            var user = new IdentityUser()
            {
                Email = model.Email,
                EmailConfirmed = true,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                await _eventBus.PublishAsync<UserCreatedEvent>("UserCreatedEvent", new UserCreatedEvent(user.Id, user.UserName, model.Address));

                notification.SetMessage("Usuário criado com sucesso!");
                notification.SetData(await _authenticationService.GenerateTokenAsync(model.Email));
            }
            else
            {
                foreach (var erro in result.Errors)
                {
                    notification.AddError(erro.Description);
                }
            }

            return notification;
        }

        public async Task<Notification> GetAllAsync()
        {
            var obj = new Notification();

            obj.SetData(_userManager.Users.ToList());

            return await Task.FromResult(obj);
        }

        public async Task<Notification> LoginAsync(UserLoginRequest model)
        {
            var notification = new Notification();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                notification.SetMessage("Usuário logado com sucesso!");
                notification.SetData(await _authenticationService.GenerateTokenAsync(model.Email));
                return notification;
            }

            notification.AddError("Usuário ou Senha incorretos");

            return notification;
        }

        public async Task<Notification> LogoutAsync(UserLoggedInRequest model)
        {
            var notification = new Notification();

            notification.SetMessage("Logout in Building");

            return await Task.FromResult(notification);
        }
    }
}
