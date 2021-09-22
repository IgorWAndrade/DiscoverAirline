using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.API.Models.Request;
using DiscoverAirline.Security.API.Services.Abastractions;
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

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            Logger.LogInformation("Start HttpPost Login with Model", model);

            if (!ModelState.IsValid)
            {
                Logger.LogError("Finish HttpPost Login with Fail ModelState", model);
                return CustomResponse(ModelState);
            }

            Logger.LogInformation("Finish HttpPost Login with Model", model);
            return CustomResponse(await _authenticationService.LoginAsync(model));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] UserLoggedInRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            return CustomResponse(await _authenticationService.LogoutAsync(model));
        }


        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] UserLoggedInRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            return CustomResponse(await _authenticationService.RefreshAsync(model));
        }


    }
}
