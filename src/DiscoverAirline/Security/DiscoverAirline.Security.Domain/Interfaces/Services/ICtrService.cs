using DiscoverAirline.Core;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface ICtrService
    {
        Task<Notification> GetAsync();
        Task<Notification> AddAsync(object model);
        Task<Notification> UpdateAsync(object model);
        Task<Notification> DeleteAsync(int id);
    }
}
