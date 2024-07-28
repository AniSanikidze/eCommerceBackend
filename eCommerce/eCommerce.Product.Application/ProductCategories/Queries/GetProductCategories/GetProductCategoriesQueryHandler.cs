using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using Mapster;

namespace eCommerce.Product.Application.ProductCategories.Queries.GetProductCategories
{
    internal sealed class GetProductCategoriesQueryHandler
        (IProductCategoryRepository productCategoryRepository) 
        : IQueryHandler<GetProductCategoriesQuery, IEnumerable<ProductCategoriesModelResponse>>
    {
        public async Task<IEnumerable<ProductCategoriesModelResponse>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productCategories = await productCategoryRepository.GetAllAsync(x => x.DeleteDate == null);
            return productCategories.Adapt<IEnumerable<ProductCategoriesModelResponse>>();
        }
    }
}
