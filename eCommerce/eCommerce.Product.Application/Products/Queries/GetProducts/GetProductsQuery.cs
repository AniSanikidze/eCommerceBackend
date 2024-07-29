using eCommerce.Common.Paging;
using eCommerce.Product.Application.Abstractions;
using Sieve.Models;

namespace eCommerce.Product.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery(SieveModel FilterModel) : IQuery<PagedResult<ProductsResponse>>;
}
