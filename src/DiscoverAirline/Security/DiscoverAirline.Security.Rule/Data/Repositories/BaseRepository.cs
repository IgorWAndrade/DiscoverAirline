using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SecurityContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SecurityContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entidade)
        {
            entidade.PrepareToAdd();
            await _context.StartTransactionAsync();
            await _dbSet.AddAsync(entidade);
            await _context.SaveChangesCommitAsync();
            return entidade;
        }

        public async Task<T> UpdateAsync(T entidade)
        {
            entidade.PrepareToUpdate();
            await _context.StartTransactionAsync();
            _dbSet.Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            await _context.SaveChangesCommitAsync();
            return entidade;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entidade = await GetByIdAsync(id);
                if (entidade != null)
                {
                    entidade.PrepareToDelete();
                    await _context.StartTransactionAsync();
                    _dbSet.Attach(entidade);
                    _context.Entry(entidade).State = EntityState.Modified;
                    await _context.SaveChangesCommitAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAsync() => await _dbSet.Where(x => x.Active).ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Active);

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression) => await _dbSet.Where(expression).ToListAsync();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => await _dbSet.AnyAsync(expression);

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression) => await _dbSet.FirstOrDefaultAsync(expression);
    }
}
