using eCommerce.Product.Domain.Base;
using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using Sieve.Services;
using System.Linq.Expressions;

namespace eCommerce.Product.Domain.Interfaces
{
    public interface IRepository<T, TId> where T : Entity<TId>
    {
        Task<T> GetByIdAsync(TId id, CancellationToken? cancellationToken = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? predicate,
                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                SieveModel? filterModel = null, ISieveProcessor? sieveProcessor = null,
                CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(IQueryable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>>? predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<T, object>? orderBy = null,
            Func<T, object>? orderByDesc = null,
            CancellationToken cancellationToken = default);
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
    }
}
