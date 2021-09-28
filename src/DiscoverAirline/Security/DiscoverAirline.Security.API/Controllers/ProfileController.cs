using DiscoverAirline.CoreAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Security.API.Controllers
{
    public class ProfileController : CoreController
    {
        public ProfileController(ILogger<CoreController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
