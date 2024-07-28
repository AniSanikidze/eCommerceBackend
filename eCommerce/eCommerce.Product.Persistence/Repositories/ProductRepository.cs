using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Persistence.Context;
using eCommerce.Product.Persistence.Repositories.Base;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;
using eCommerce.Product.Domain.Aggregates.Products;

namespace eCommerce.Product.Persistence.Repositories
{
    internal class ProductRepository : Repository<ProductEntity, Guid>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }

        public async Task<ProductEntity> GetByIdWithCategoriesAsync(Guid productId)
        {
            //Todo: include Product Categories
            return await GetAsync(
                predicate: x => x.Id == productId && x.DeleteDate == null);
        }
    }
}
