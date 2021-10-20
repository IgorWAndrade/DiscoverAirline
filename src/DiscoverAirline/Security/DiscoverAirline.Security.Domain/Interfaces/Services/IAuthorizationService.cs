using DiscoverAirline.Core;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<Notification> ManagementToAuthorizations(object auth);
        Task<Notification> ManagementToUsers(object model);
    }
}
