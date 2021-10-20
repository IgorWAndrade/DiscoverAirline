using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class ActController : CoreController
    {
        private readonly IActService _service;

        public ActController(
            ILogger<CoreController> logger,
            IActService service) : base(logger)
        {
            _service = service;
        }


        [HttpGet("Actions")]
        [AuthorizationCustom("Security", "AuthorizationController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

    }
}
