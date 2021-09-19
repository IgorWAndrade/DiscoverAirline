using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Settings;
using DiscoverAirline.Security.API.Models.Request;
using DiscoverAirline.Security.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AuthenticationController : CoreController
    {
        private readonly SecuritySettings _securitySettings;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolerManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthenticationController(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> rolerManager,
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _securitySettings = configuration.GetSection("SecuritySettings").Get<SecuritySettings>();
            _userManager = userManager;
            _rolerManager = rolerManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(CustomResponse(await _tokenService.GenerateTokenAsync(model.Email)));
            }
            else
            {
                return BadRequest("Usuário ou Senha incorretos");
            }


        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] UserLoggedInRequest model) => Ok("Logout in Building");

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] UserLoggedInRequest model) => Ok("Refresh in Building");


    }
}
