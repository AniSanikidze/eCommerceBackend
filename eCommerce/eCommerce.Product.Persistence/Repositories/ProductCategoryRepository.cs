using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Persistence.Context;
using eCommerce.Product.Persistence.Repositories.Base;

namespace eCommerce.Product.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetByIdsAsync(List<Guid> CategoryIds)
        {
            return await GetAllAsync(predicate: x => CategoryIds.Contains(x.Id) && x.DeleteDate == null);
        }
    }
}
