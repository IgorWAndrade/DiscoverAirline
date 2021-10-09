using DiscoverAirline.Security.API.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Core.Services
{
    public interface IAuthenticationService
    {
        Task<UserDefaultResponse> GenerateTokenAsync(IdentityUser user);

        Task<UserDefaultResponse> RefreshTokenAsync(UserLoggedInRequest tokenRequest);
    }
}
