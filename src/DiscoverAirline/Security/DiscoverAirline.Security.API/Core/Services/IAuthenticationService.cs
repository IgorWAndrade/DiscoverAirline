using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Notification> RefreshAsync(UserLoggedInRequest model);
        Task<UserDefaultResponse> GenerateTokenAsync(string email);
    }
}
