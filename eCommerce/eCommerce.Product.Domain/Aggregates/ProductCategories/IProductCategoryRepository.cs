using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Domain.Aggregates.ProductCategories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, Guid>
    {
        Task<IEnumerable<ProductCategory>> GetByIdsAsync(List<Guid> ProductCategoryIds);
    }
}
