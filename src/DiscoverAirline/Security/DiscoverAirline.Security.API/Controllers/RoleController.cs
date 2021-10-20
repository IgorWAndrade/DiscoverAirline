using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class RoleController : CoreController
    {
        private readonly IRoleService _service;

        public RoleController(
            ILogger<CoreController> logger,
            IRoleService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("Get")]
        [AuthorizationCustom("Security", "RoleController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

        [HttpPost("Post")]
        [AuthorizationCustom("Security", "RoleController", "Post")]
        public async Task<IActionResult> Post([FromBody] RoleCreateRequest model) => CustomResponse(await _service.AddAsync(model));

        [HttpPut("Put")]
        [AuthorizationCustom("Security", "RoleController", "Put")]
        public async Task<IActionResult> Put([FromBody] RoleUpdateRequest model) => CustomResponse(await _service.UpdateAsync(model));

        [HttpDelete("Delete")]
        [AuthorizationCustom("Security", "RoleController", "Delete")]
        public async Task<IActionResult> Delete([FromBody] int id) => CustomResponse(await _service.DeleteAsync(id));

    }
}
