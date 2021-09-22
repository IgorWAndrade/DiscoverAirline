using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models.Request;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services.Abastractions
{
    public interface IAuthenticationService
    {
        Task<Notification> LoginAsync(UserLoginRequest model);
        Task<Notification> LogoutAsync(UserLoggedInRequest model);
        Task<Notification> RefreshAsync(UserLoggedInRequest model);
    }
}
