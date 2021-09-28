using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class UserController : CoreController
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService,
            IAuthenticationService authenticationService) : base(logger)
        {
            _userService = userService;
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

            return CustomResponse(await _userService.CreateAsync(model));
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
        public async Task<IActionResult> Signout([FromBody] UserLoggedInRequest model)
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllAsync();

            return CustomResponse(result);
        }
    }
}
