using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Customer.API.Controllers
{
    public class HomeController : CoreController
    {
        private readonly IMemoryCache _memoryCache;
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache) : base(logger)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Ok(_memoryCache.Get("ListAddress"));
        }

        [HttpPost]
        [AuthorizationCustom(nameof(HomeController), "Customer", "add")]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
