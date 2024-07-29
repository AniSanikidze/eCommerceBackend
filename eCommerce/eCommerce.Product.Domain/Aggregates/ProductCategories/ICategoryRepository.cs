using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Domain.Aggregates.ProductCategories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<IEnumerable<Category>> GetByIdsAsync(List<Guid> CategoryIds);
    }
}
