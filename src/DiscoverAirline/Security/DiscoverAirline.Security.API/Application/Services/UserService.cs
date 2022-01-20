using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Application.Services.Interfaces;
using DiscoverAirline.Security.API.Application.ViewModels;
using DiscoverAirline.Security.API.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(
            ITokenService tokenService,
            ApplicationDbContext applicationDbContext)
        {
            _tokenService = tokenService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Notification> LoginAsync(UsuarioLogin userRequest)
        {
            return Notification.Create(); 
        }

        public async Task<Notification> LoginRefreshAsync(string refreshToken)
        {
            //var userId = _applicationDbContext.AspNetUsersRefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken)).UserId;
            //var user = await _userManager.FindByIdAsync(userId);

            //if (user != null)
            //{
            //    await LogoutAsync(user.Email);

            //    var roles = await _userManager.GetRolesAsync(user);
            //    var claims = await _userManager.GetClaimsAsync(user);
            //    return Notification.Create(await _tokenService.GenerateTokenAsync(user, roles, claims));
            //}

            var notification = Notification.Create();
           
            notification.AddError("Refresh token invalído.");
            return notification;
        }

        public async Task<Notification> LogoutAsync(string email)
        {
            var notification = Notification.Create();

            //var user = await _userManager.FindByEmailAsync(email);
            //if (user != null)
            //{
            //    var storedRefreshToken = _applicationDbContext.AspNetUsersRefreshTokens.FirstOrDefault(x => x.UserId.Equals(user.Id));
            //    _applicationDbContext.AspNetUsersRefreshTokens.Remove(storedRefreshToken);
            //    await _signInManager.SignOutAsync();
            //}
            //else
            //{
            //    notification.AddError("Usuario não existe!");
            //}

            return notification;
        }

        public async Task<Notification> RegisterAsync(UsuarioRegistro userRequest)
        {
            //var user = new IdentityUser
            //{
            //    UserName = userRequest.Email,
            //    Email = userRequest.Email,
            //    EmailConfirmed = true
            //};

            //var result = await _userManager.CreateAsync(user, userRequest.Senha);

            //if (result.Succeeded)
            //{
            //    var roles = await _userManager.GetRolesAsync(user);
            //    var claims = await _userManager.GetClaimsAsync(user);
            //    return Notification.Create(await _tokenService.GenerateTokenAsync(user, roles, claims));
            //}

            var notification = Notification.Create();
            
            return notification;
        }
    }
}
