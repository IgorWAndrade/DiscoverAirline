using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.API.Application.Services.Interfaces;
using DiscoverAirline.Security.API.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AuthenticationController : CoreController
    {
        private readonly IUserService _userService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpPost("Signup")]
        [AllowAnonymous]
        public async Task<IActionResult> Signup([FromBody] UsuarioRegistro usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _userService.RegisterAsync(usuarioLogin));
        }

        [HttpPost("Signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Signin([FromBody] UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _userService.LoginAsync(usuarioLogin));
        }

        [HttpPost("Signout")]
        public async Task<IActionResult> Signout() => CustomResponse(await _userService.LogoutAsync(User.Identity.Name));

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type.Equals("RefreshToken")).Value;

            return CustomResponse(await _userService.LoginRefreshAsync(token));
        }

    }
}
