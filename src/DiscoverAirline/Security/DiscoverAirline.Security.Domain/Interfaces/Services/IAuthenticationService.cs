using DiscoverAirline.Core;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Notification> RegisterAsync(object model);
        Task<Notification> LoginAsync(object user);
        Task LogoutAsync(string name);
        Task<Notification> RefreshTokenAsync(string userRefresh);
    }
}
