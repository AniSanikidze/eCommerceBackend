using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.Products.Queries.GetProduct
{
    public record GetProductQuery(Guid Id) : IQuery<ProductResponse>;
}
