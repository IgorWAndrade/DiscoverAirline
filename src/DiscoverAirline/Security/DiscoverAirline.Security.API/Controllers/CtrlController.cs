using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class CtrlController : CoreController
    {
        private readonly ICtrService _service;

        public CtrlController(
            ILogger<CoreController> logger,
            ICtrService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("Controllers")]
        //[AuthorizationCustom("Security", "AuthorizationController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

        [HttpPost("Controllers")]
        //[AuthorizationCustom("Security", "AuthorizationController", "Post")]
        public async Task<IActionResult> Create([FromBody] ControllerRequest model) => CustomResponse(await _service.AddAsync(model));


        [HttpPut("Controllers")]
        [AuthorizationCustom("Security", "AuthorizationController", "Put")]
        public async Task<IActionResult> Update([FromBody] ControllerUpdateRequest model) => CustomResponse(await _service.UpdateAsync(model));


        [HttpDelete("Controllers")]
        [AuthorizationCustom("Security", "AuthorizationController", "Delete")]
        public async Task<IActionResult> Delete([FromBody] int id) => CustomResponse(await _service.DeleteAsync(id));
    }
}
