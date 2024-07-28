using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Exceptions;
using eCommerce.Product.Domain.Aggregates.Products;
using Mapster;

namespace eCommerce.Product.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductQuery, GetProductResponse>
    {
        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //TODO: include categories, if admin hide stockQuantity, add imageurl
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product == null || product.DeleteDate != null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            return product.Adapt<GetProductResponse>();
        }
    }
}
