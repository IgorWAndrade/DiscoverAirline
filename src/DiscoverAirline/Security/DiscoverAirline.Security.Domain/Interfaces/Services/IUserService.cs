using DiscoverAirline.Security.Domain.Entities;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> AddAsync(object userRequest);
        Task<User> LoginAsync(string userName, string userPassword);
    }
}
