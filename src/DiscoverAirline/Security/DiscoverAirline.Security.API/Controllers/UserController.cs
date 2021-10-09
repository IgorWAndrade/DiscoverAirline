using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.API.Application.Dtos;
using DiscoverAirline.Security.API.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class UserController : CoreController
    {
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService) : base(logger)
        {
            _userService = userService;
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

            return CustomResponse(await _userService.LoginAsync(model));
        }

        [HttpPost("Signout")]
        public async Task<IActionResult> Signout([FromBody] UserLoggedInRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            return CustomResponse(await _userService.LogoutAsync(model));
        }

        [HttpPost("Refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromBody] UserLoggedInRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            return CustomResponse(await _userService.ReLoginAsync(model));
        }
    }
}
