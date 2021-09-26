using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models.Request;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services.Abastractions
{
    public interface IUserService
    {
        Task<Notification> CreateAsync(UserRegisterRequest model);
        Task<Notification> GetAllAsync();
    }
}
