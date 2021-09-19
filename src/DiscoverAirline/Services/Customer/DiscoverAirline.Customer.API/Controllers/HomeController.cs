using DiscoverAirline.CoreAPI;
using Microsoft.AspNetCore.Mvc;

namespace DiscoverAirline.Customer.API.Controllers
{
    public class HomeController : CoreController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(User.Identity.Name);
        }
    }
}
