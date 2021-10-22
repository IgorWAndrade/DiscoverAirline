using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context)
        {
        }

        public async Task<User> FirstFullAsync(Expression<Func<User, bool>> expression)
        {
            return await _dbSet
                .Include(x => x.Role)
                .Include(x => x.Token)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<User> GetFullAsync(string userName)
        {
            return await _dbSet
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email.Equals(userName));
        }


    }
}
