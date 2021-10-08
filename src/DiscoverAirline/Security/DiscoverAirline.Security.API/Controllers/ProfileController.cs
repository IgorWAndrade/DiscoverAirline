using DiscoverAirline.CoreAPI;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Security.API.Controllers
{
    public class ProfileController : CoreController
    {
        public ProfileController(ILogger<CoreController> logger) : base(logger)
        {
        }
    }
}
