using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
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

        [HttpGet("GetByUser")]
        [AuthorizationCustom("Security", "UserController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _userService.GetFullAsync(User.Identity.Name));
    }
}
