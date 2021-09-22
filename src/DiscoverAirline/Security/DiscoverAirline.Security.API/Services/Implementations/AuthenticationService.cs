using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models.Request;
using DiscoverAirline.Security.API.Services.Abastractions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthenticationService(
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Notification> LoginAsync(UserLoginRequest model)
        {
            var notification = new Notification();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                notification.SetMessage("Usuário logado com sucesso!");
                notification.SetData(await _tokenService.GenerateTokenAsync(model.Email));
                return notification;
            }

            notification.AddError("Usuário ou Senha incorretos");

            return notification;
        }

        public async Task<Notification> RefreshAsync(UserLoggedInRequest model)
        {
            var notification = new Notification();

            notification.SetMessage("Refresh in Building");

            return await Task.FromResult(notification);
        }

        public async Task<Notification> LogoutAsync(UserLoggedInRequest model)
        {
            var notification = new Notification();

            notification.SetMessage("Logout in Building");

            return await Task.FromResult(notification);
        }
    }
}
