using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.Applications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class ApplicationController : CoreController
    {
        private readonly IApplicationService _service;

        public ApplicationController(
            ILogger<CoreController> logger,
            IApplicationService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("Application")]
        [AuthorizationCustom("Security", "ApplicationController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

        [HttpPost("Application")]
        [AuthorizationCustom("Security", "ApplicationController", "Post")]
        public async Task<IActionResult> Create([FromBody] ApplicationCreateRequest model) => CustomResponse(await _service.AddAsync(model));


        [HttpPut("Application")]
        [AuthorizationCustom("Security", "ApplicationController", "Put")]
        public async Task<IActionResult> Update([FromBody] ApplicationUpdateRequest model) => CustomResponse(await _service.UpdateAsync(model));


        [HttpDelete("Application")]
        [AuthorizationCustom("Security", "ApplicationController", "Delete")]
        public async Task<IActionResult> Delete([FromBody] int id) => CustomResponse(await _service.DeleteAsync(id));

    }
}
