using eCommerce.Product.Domain.Interfaces;
using Sieve.Models;
using Sieve.Services;

namespace eCommerce.Product.Domain.Aggregates.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Product> GetByIdWithCategoriesAsync(Guid productId);
        IQueryable<Product> GetProducts(SieveModel filterModel, ISieveProcessor sieveProcessor);
    }
}
