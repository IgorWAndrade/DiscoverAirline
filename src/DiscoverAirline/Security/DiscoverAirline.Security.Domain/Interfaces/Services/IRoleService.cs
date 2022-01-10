using DiscoverAirline.Core;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface IRoleService
    {
        Task<Notification> GetAsync();
        Task<Notification> AddAsync(object model);
        Task<Notification> AttachUsersAsync(object model);
        Task<Notification> UpdateAsync(object model);
        Task<Notification> DeleteAsync(int id);
        Task<Notification> DetachUsersAsync(object model);

    }
}
