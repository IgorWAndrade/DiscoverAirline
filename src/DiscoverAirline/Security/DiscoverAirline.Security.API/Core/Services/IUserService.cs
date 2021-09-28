using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Core.Services
{
    public interface IUserService
    {
        Task<Notification> LoginAsync(UserLoginRequest model);
        Task<Notification> LogoutAsync(UserLoggedInRequest model);
        Task<Notification> CreateAsync(UserRegisterRequest model);
        Task<Notification> GetAllAsync();
    }
}
