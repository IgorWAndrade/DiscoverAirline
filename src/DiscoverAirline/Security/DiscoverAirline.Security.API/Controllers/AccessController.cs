using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AccessController : CoreController
    {
        private readonly IAccessService _service;

        public AccessController(
            ILogger<CoreController> logger,
            IAccessService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("Access")]
        [AuthorizationCustom("Security", nameof(AccessController), "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

        [HttpPost("Access")]
        [AuthorizationCustom("Security", nameof(AccessController), "Post")]
        public async Task<IActionResult> Create([FromBody] AccessCreateRequest model) => CustomResponse(await _service.AddAsync(model));


        [HttpPut("Access")]
        [AuthorizationCustom("Security", nameof(AccessController), "Put")]
        public async Task<IActionResult> Update([FromBody] AccessUpdateRequest model) => CustomResponse(await _service.UpdateAsync(model));


        [HttpDelete("Access")]
        [AuthorizationCustom("Security", nameof(AccessController), "Delete")]
        public async Task<IActionResult> Delete([FromBody] int id) => CustomResponse(await _service.DeleteAsync(id));
    }
}
