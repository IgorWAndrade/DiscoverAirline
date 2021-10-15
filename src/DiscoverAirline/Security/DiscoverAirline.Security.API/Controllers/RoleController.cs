using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Attribute;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class RoleController : CoreController
    {
        private readonly IRoleService _roleService;
        public RoleController(
            ILogger<CoreController> logger,
            IRoleService roleService) : base(logger)
        {
            _roleService = roleService;
        }

        [HttpGet("Get")]
        [AuthorizationCustom("Security", "RoleController", "Get")]
        public async Task<IActionResult> Get() => CustomResponse(await _roleService.GetAsync());


        [HttpPost("Post")]
        [AuthorizationCustom("Security", "RoleController", "Post")]
        public async Task<IActionResult> Post([FromBody] RoleCreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            return CustomResponse(await _roleService.AddAsync(model));
        }
    }
}
