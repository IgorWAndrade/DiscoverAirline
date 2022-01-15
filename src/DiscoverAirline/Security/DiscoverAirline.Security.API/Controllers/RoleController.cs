using DiscoverAirline.CoreAPI;
using DiscoverAirline.CoreAPI.Utils;
using DiscoverAirline.Security.API.Application.ViewModels;
using DiscoverAirline.Security.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Controllers
{
    public class RoleController : CoreController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RoleController(ILogger<CoreController> logger, ApplicationDbContext applicationDbContext) : base(logger)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [Authorize(Policy = "Role:HttpPost")]
        public async Task<IActionResult> Post([FromBody] RoleViewModel viewModel)
        {
            var identityRole = new IdentityRole
            {
                Name = viewModel.Name,
                NormalizedName = viewModel.NormalizedName
            };

            var result = await _applicationDbContext.Roles.AddAsync(identityRole);
            return Ok(result);
        }

        [HttpPut("id")]
        [Authorize(Policy = "Role:HttpPut")]
        public async Task<IActionResult> Put(string id, [FromBody] RoleViewModel viewModel)
        {
            var role = await _applicationDbContext.Roles.FindAsync(id);

            role.Name = viewModel.Name;
            role.NormalizedName = viewModel.NormalizedName;

            _applicationDbContext.Roles.Update(role);
            var result = await _applicationDbContext.SaveChangesAsync() > 0 ? true : false;
            return Ok(result);
        }

        [HttpDelete("id")]
        [Authorize(Policy = "Role:HttpDelete")]
        public async Task<IActionResult> Delete(string id)
        {
            var roleClaims = await _applicationDbContext.RoleClaims.Where(x => x.RoleId == id).ToListAsync();
            foreach (var item in roleClaims)
            {
                _applicationDbContext.RoleClaims.Remove(item);
            }

            var userRoles = await _applicationDbContext.UserRoles.Where(x => x.RoleId == id).ToListAsync();
            foreach (var item in userRoles)
            {
                _applicationDbContext.UserRoles.Remove(item);
            }

            var role = await _applicationDbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            _applicationDbContext.Roles.Remove(role);

            return Ok(true);
        }

        [HttpGet("id")]
        [Authorize(Policy = "Role:HttpGet")]
        public async Task<IActionResult> Get(int id) => Ok(await _applicationDbContext.Roles.FindAsync(id));

        [HttpGet("GetAll")]
        [Authorize(Policy = "Role:HttpGet")]
        public async Task<IActionResult> GetAll() => Ok(await _applicationDbContext.Roles.ToListAsync());
    }
}
