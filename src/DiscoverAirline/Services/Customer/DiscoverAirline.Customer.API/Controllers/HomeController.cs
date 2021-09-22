using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Customer.API.Controllers
{
    public class HomeController : CoreController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(User.Identity.Name);
        }

        [HttpPost]
        [AuthorizationCustom(nameof(HomeController), "Customer", "add")]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
