using eCommerce.Common.Exceptions;
using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Services;
using eCommerce.Product.Domain.Aggregates.Products;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Product.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler(
        IProductRepository productRepository,
        IUserResolverService userResolverService) : IQueryHandler<GetProductQuery, ProductResponse>
    {
        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAsync(
                predicate: x => x.Id == request.Id,
                include: x => x.Include(x => x.ProductCategories.Where(x => x.DeleteDate == null)),
                cancellationToken: cancellationToken);

            if (product == null || product.DeleteDate != null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            if (!userResolverService.IsAdmin())
                product.SetStockQuantity(-1);

            return product.Adapt<ProductResponse>();
        }
    }
}
