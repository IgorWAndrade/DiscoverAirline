using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<Notification> AddAsync(object userRequest);
        Task<Notification> LoginAsync(string userName, string userPassword);
        Task<Notification> GetFullAsync(string userName);
    }
}
