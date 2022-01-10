using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class ActionController : CoreController
    {
        private readonly IActionService _service;

        public ActionController(
            ILogger<CoreController> logger,
            IActionService service) : base(logger)
        {
            _service = service;
        }


        [HttpGet("Actions")]
        [AuthorizationCustom("Security", nameof(ActionController), "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

    }
}
