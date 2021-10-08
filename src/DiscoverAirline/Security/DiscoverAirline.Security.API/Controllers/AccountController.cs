using DiscoverAirline.CoreAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AccountController : CoreController
    {
        public AccountController(ILogger<AccountController> logger) : base(logger)
        {
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok("User Logged");
        }
    }
}
