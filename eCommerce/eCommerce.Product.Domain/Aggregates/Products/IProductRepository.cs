using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Domain.Aggregates.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Product> GetByIdWithCategoriesAsync(Guid productId);
    }
}
