using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AuthenticationController : CoreController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthenticationService authenticationService) : base(logger)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Signup")]
        [AllowAnonymous]
        public async Task<IActionResult> Signup([FromBody] UserRegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            return CustomResponse(await _authenticationService.RegisterAsync(model));
        }

        [HttpPost("Signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Signin([FromBody] UserLoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            return CustomResponse(await _authenticationService.LoginAsync(model));
        }

        [HttpPost("Signout")]
        public async Task<IActionResult> Signout()
        {
            await _authenticationService.LogoutAsync(HttpContext.User.Identity.Name);

            return CustomResponse();
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            if (!ModelState.IsValid)
            {
                Notification.AddError("Usuario ou Senha invalidos!");
                return CustomResponse();
            }

            return CustomResponse(await _authenticationService.RefreshTokenAsync(refreshToken));

        }

    }
}
