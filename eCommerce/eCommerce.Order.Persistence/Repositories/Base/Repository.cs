using eCommerce.Order.Domain.Base;
using eCommerce.Order.Domain.Interfaces;
using eCommerce.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using Sieve.Services;
using System.Linq.Expressions;

namespace eCommerce.Order.Persistence.Repositories.Base
{
    public class Repository<T, TId> : IRepository<T, TId> where T : Entity<TId>
    {
        protected readonly OrderDbContext _context;

        public Repository(OrderDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(IQueryable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate)
        {
            var quaryable = _context.Set<T>().AsQueryable();
            if(predicate != null) quaryable = quaryable.Where(predicate);
            return await quaryable.ToListAsync();
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        SieveModel? filterModel = null, ISieveProcessor? sieveProcessor = null,
        CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = _context.Set<T>();
            if (include != null) queryable = include(queryable);
            if (filterModel != null && sieveProcessor != null) queryable = sieveProcessor.Apply(filterModel, queryable, applyPagination: false);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);

            return queryable;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<T, object>? orderBy = null,
            Func<T, object>? orderByDesc = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = _context.Set<T>();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) return queryable.MinBy(orderBy);
            if (orderByDesc != null) return queryable.MaxBy(orderByDesc);

            return await queryable.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
