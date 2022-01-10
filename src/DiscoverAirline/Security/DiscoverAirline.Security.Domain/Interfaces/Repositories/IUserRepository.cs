using DiscoverAirline.Security.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetFullAsync(string userName);
        Task<User> FirstFullAsync(Expression<Func<User, bool>> expression);
    }
}
