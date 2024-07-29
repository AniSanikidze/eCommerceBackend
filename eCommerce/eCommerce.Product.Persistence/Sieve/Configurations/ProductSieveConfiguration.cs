using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;
using Sieve.Services;

namespace eCommerce.Product.Persistence.Sieve.Configurations
{
    public class ProductSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<ProductEntity>(a => a.Name)
                .CanFilter();

            mapper.Property<ProductEntity>(a => a.Description)
                .CanFilter();

            mapper.Property<ProductEntity>(a => a.Price)
                .CanSort()
                .CanFilter();

            mapper.Property<ProductEntity>(a => a.StockQuantity)
                .CanFilter();
        }
    }
}
