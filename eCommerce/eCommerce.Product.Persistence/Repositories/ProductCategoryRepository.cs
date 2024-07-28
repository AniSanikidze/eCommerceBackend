using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Persistence.Context;
using eCommerce.Product.Persistence.Repositories.Base;

namespace eCommerce.Product.Persistence.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory, Guid>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductCategory>> GetByIdsAsync(List<Guid> ProductCategoryIds)
        {
            return await GetAllAsync(predicate: x => ProductCategoryIds.Contains(x.Id) && x.DeleteDate == null);
        }
    }
}
