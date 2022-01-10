using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreBroker.Abstractions;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Events.Integrations;
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
        private readonly IEventBus _eventBus;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService,
            IEventBus eventBus) : base(logger)
        {
            _userService = userService;
            _eventBus = eventBus;
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> Get() => CustomResponse(await _userService.GetFullAsync(User.Identity.Name));
    }
}
