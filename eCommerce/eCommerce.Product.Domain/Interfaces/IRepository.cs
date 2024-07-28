using eCommerce.Product.Domain.Base;
using System.Linq.Expressions;

namespace eCommerce.Product.Domain.Interfaces
{
    public interface IRepository<T, TId> where T : Entity<TId>
    {
        Task<T> GetByIdAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(IQueryable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
    }
}
