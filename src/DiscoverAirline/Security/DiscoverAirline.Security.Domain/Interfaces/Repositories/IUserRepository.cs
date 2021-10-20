using DiscoverAirline.Security.Domain.Entities;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetFullAsync(string userName);
    }
}
