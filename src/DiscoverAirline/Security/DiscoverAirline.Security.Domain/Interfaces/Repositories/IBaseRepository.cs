using DiscoverAirline.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        #region Escrita
        Task<T> AddAsync(T entidade);

        Task<T> UpdateAsync(T entidade);

        Task<bool> DeleteAsync(int id);
        #endregion

        #region Leitura
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAsync();

        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<T> FirstAsync(Expression<Func<T, bool>> expression);
        #endregion
    }
}
