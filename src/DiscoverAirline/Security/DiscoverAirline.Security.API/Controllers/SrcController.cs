using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class SrcController : CoreController
    {
        private readonly ISrcService _service;

        public SrcController(
            ILogger<CoreController> logger,
            ISrcService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("Services")]
        [AuthorizationCustom("Security", "AuthorizationController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

        [HttpPost("Services")]
        [AuthorizationCustom("Security", "AuthorizationController", "Post")]
        public async Task<IActionResult> Create([FromBody] ServiceRequest model) => CustomResponse(await _service.AddAsync(model));


        [HttpPut("Services")]
        [AuthorizationCustom("Security", "AuthorizationController", "Put")]
        public async Task<IActionResult> Update([FromBody] ServiceRequest model) => CustomResponse(await _service.UpdateAsync(model));


        [HttpDelete("Services")]
        [AuthorizationCustom("Security", "AuthorizationController", "Delete")]
        public async Task<IActionResult> Delete([FromBody] int id) => CustomResponse(await _service.DeleteAsync(id));

    }
}
