using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.User;
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
        public async Task<IActionResult> Signup([FromBody] UserRegisterRequest model) => CustomResponse(await _authenticationService.RegisterAsync(model));

        [HttpPost("Signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Signin([FromBody] UserLoginRequest model) => CustomResponse(await _authenticationService.LoginAsync(model));

        [HttpPost("Signout")]
        public async Task<IActionResult> Signout() => CustomResponse(await _authenticationService.LogoutAsync(HttpContext.User.Identity.Name));

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken) => CustomResponse(await _authenticationService.RefreshTokenAsync(refreshToken));

    }
}
