using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Events.Integrations;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Get() => CustomResponse(await _userService.GetFullAsync(User.Identity.Name));
    }
}
