using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Customer.API.Controllers
{
    public class HomeController : CoreController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger) { }

        [HttpPost]
        [AuthorizationCustom("Customer", nameof(HomeController), "Post")]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPost("Get")]
        [AuthorizationCustom("Customer", nameof(HomeController), "Get")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
