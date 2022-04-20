using Microsoft.EntityFrameworkCore;
using ShopBridge.Data.Core.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopBridge.Data.Providers
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public ReadOnlyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> FindByAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public virtual async Task<TEntity> FindByIdAsync(params object[] ids)
        {
            var result = await _dbSet.FindAsync(ids);

            if (result is not null)
            {
                _dbContext.Entry(result).State = EntityState.Detached;
            }

            return result;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
    }
}
