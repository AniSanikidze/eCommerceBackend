using eCommerce.Common.Paging;
using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Domain.Aggregates.Products;
using Sieve.Services;

namespace eCommerce.Product.Application.Products.Queries.GetProducts
{
    internal class GetProductsQueryHandler(
        IProductRepository productRepository,
        ISieveProcessor sieveProcessor) : IQueryHandler<GetProductsQuery, PagedResult<ProductsResponse>>
    {
        public async Task<PagedResult<ProductsResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = productRepository.GetProducts(request.FilterModel, sieveProcessor);

            return await PagedResult<ProductsResponse>
                .CreateAsync(products, request.FilterModel.Page, request.FilterModel.PageSize);
        }
    }
}
