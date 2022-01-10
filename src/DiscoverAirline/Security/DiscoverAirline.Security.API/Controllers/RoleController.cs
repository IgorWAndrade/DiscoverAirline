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
        [AuthorizationCustom("Security", nameof(RoleController), "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _service.GetAsync());

        [HttpPost("Post")]
        [AuthorizationCustom("Security", nameof(RoleController), "Post")]
        public async Task<IActionResult> Post([FromBody] RoleCreateRequest model) => CustomResponse(await _service.AddAsync(model));

        [HttpPost("AddUsers")]
        [AuthorizationCustom("Security", nameof(RoleController), "Post")]
        public async Task<IActionResult> AddUsersToRole([FromBody] RoleAttachUsersRequest model) => CustomResponse(await _service.AttachUsersAsync(model));

        [HttpPut("Put")]
        [AuthorizationCustom("Security", nameof(RoleController), "Put")]
        public async Task<IActionResult> Put([FromBody] RoleUpdateRequest model) => CustomResponse(await _service.UpdateAsync(model));

        [HttpDelete("Delete")]
        [AuthorizationCustom("Security", nameof(RoleController), "Delete")]
        public async Task<IActionResult> Delete([FromBody] int id) => CustomResponse(await _service.DeleteAsync(id));

        [HttpDelete("RemoveUsers")]
        [AuthorizationCustom("Security", nameof(RoleController), "Delete")]
        public async Task<IActionResult> DeleteUsersToRole([FromBody] RoleDetachUsersRequest model) => CustomResponse(await _service.DetachUsersAsync(model));

    }
}
