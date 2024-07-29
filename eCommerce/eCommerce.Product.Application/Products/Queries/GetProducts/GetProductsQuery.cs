using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Common.Paging;
using Sieve.Models;

namespace eCommerce.Product.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery(SieveModel FilterModel) : IQuery<PagedResult<ProductsResponse>>;
}
