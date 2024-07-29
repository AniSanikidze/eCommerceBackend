using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Persistence.Context;
using eCommerce.Product.Persistence.Repositories.Base;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;
using eCommerce.Product.Domain.Aggregates.Products;
using System.Threading;
using Sieve.Services;
using Sieve.Models;
using Microsoft.EntityFrameworkCore;

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
                predicate: x => x.Id == productId && x.DeleteDate == null,
                include: x => x.Include(x => x.ProductCategories.Where(x => x.DeleteDate == null)));
        }

        public IQueryable<ProductEntity> GetProducts(SieveModel filterModel, ISieveProcessor sieveProcessor)
        {
            return GetAllQueryable(
               predicate: x => x.DeleteDate == null,
               orderBy: x => x.OrderByDescending(x => x.CreateDate),
               sieveProcessor: sieveProcessor,
               filterModel: filterModel);
        }
    }
}
