using eCommerce.Product.Domain.Base;
using eCommerce.Product.Domain.Interfaces;
using eCommerce.Product.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Product.Persistence.Repositories.Base
{
    public class Repository<T, TId> : IRepository<T, TId> where T : Entity<TId>
    {
        protected readonly ProductDbContext _context;

        public Repository(ProductDbContext context)
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate)
        {
            var quaryable = _context.Set<T>();
            if(predicate != null) quaryable.Where(predicate);
            return await quaryable.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();

        }

        public Task<T> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
