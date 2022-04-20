using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopBridge.Data.Core.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindByAsNoTracking(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindByIdAsync(params object[] ids);

        IQueryable<TEntity> GetAll();
    }
}
