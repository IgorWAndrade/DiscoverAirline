using DiscoverAirline.CoreAPI;
using Microsoft.Extensions.Logging;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AccountController : CoreController
    {
        public AccountController(ILogger<AccountController> logger) : base(logger)
        {
        }

    }
}
