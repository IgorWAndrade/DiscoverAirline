using DiscoverAirline.Core;
using DiscoverAirline.CoreBroker;
using DiscoverAirline.Security.API.Events;
using DiscoverAirline.Security.API.Models.Request;
using DiscoverAirline.Security.API.Services.Abastractions;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolerManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMessageBrokerPublish _messageBroker;

        public UserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> rolerManager,
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService,
            IMessageBrokerPublish messageBroker)
        {
            _userManager = userManager;
            _rolerManager = rolerManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _messageBroker = messageBroker;
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

                var @event = new UserCreatedEvent(user.Id, user.UserName, model.Address);
                _messageBroker.Publish("UserCreated_SecurityService", UserCreatedEvent.Create("SecurityService", "CustomerService", @event));

                notification.SetMessage("Usuário criado com sucesso!");
                notification.SetData(await _tokenService.GenerateTokenAsync(model.Email));
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
    }
}
