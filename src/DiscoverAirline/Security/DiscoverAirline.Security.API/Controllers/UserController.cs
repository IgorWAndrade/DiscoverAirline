using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.API.Models.Request;
using DiscoverAirline.Security.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class UserController : CoreController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolerManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> rolerManager,
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _rolerManager = rolerManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var user = new IdentityUser()
            {
                Email = model.Email,
                EmailConfirmed = true,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //Publish - User.Id , User.Address

                return Ok(CustomResponse(await _tokenService.GenerateTokenAsync(model.Email)));
            }

            return BadRequest(result.Errors);
        }

    }
}
