using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repositorio;

        public BaseService(IBaseRepository<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<T> AddAsync(T entidade) => await _repositorio.AddAsync(entidade);

        public async Task<T> UpdateAsync(T entidade) => await _repositorio.UpdateAsync(entidade);

        public async Task<bool> DeleteAsync(int id) => await _repositorio.DeleteAsync(id);

        public async Task<IEnumerable<T>> GetAsync() => await _repositorio.GetAsync();

        public async Task<T> GetByIdAsync(int id) => await _repositorio.GetByIdAsync(id);

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression) => await _repositorio.WhereAsync(expression);
    }
}
