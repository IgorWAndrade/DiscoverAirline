using DiscoverAirline.Core;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface IActionService
    {
        Task<Notification> GetAsync();
    }
}
