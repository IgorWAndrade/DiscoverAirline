using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.Security.API.Core.Services;
using DiscoverAirline.Security.API.Services.Dtos;
using DiscoverAirline.Security.API.Services.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
