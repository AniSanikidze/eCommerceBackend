using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;
using Sieve.Services;

namespace eCommerce.Product.Persistence.Sieve.Configurations
{
    public class ProductSieveCustomFilter(/*IUserResolverService userResolverService*/) : ISieveCustomFilterMethods
    {
        public IQueryable<ProductEntity> StockQuantity(IQueryable<ProductEntity> source, string op, string[] values)
        {
            //if (!userResolverService.IsAdmin())
            //    return source;

            var quantity = Convert.ToInt32(values[0]);

            return op switch
            {
                "==" => source.Where(x => x.StockQuantity == quantity),
                "!=" => source.Where(x => x.StockQuantity != quantity),
                ">" => source.Where(x => x.StockQuantity > quantity),
                ">=" => source.Where(x => x.StockQuantity >= quantity),
                "<" => source.Where(x => x.StockQuantity < quantity),
                "<=" => source.Where(x => x.StockQuantity <= quantity),
                _ => source,
            };
        }
    }
}
