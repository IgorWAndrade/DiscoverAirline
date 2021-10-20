using DiscoverAirline.CoreAPI;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class AuthorizationController : CoreController
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(
            ILogger<CoreController> logger,
            IAuthorizationService authorizationService) : base(logger)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("ManageFromSecurityToRole")]
        //[AuthorizationCustom("Security", "AuthorizationController", "Put")]
        public async Task<IActionResult> ManageRoleAuthorization([FromBody] AuthManagerRequest model) => CustomResponse(await _authorizationService.ManagementToAuthorizations(model));

        [HttpPost("ManageFromSecuritiesToRole")]
        //[AuthorizationCustom("Security", "AuthorizationController", "Put")]
        public async Task<IActionResult> ManageRoleAuthorizations([FromBody] AuthManagersRequest model) => CustomResponse(await _authorizationService.ManagementToAuthorizations(model));

        [HttpPost("ManageFromRoleToUsers")]
        //[AuthorizationCustom("Security", "AuthorizationController", "Put")]
        public async Task<IActionResult> ManageFromRoleToUsers([FromBody] AuthManagersUsersRequest model) => CustomResponse(await _authorizationService.ManagementToUsers(model));

    }
}
