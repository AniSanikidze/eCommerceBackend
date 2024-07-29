using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.ProductCategories.Queries.GetCategories;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using Mapster;

namespace eCommerce.Product.Application.ProductCategories.Queries.GetProductCategories
{
    internal sealed class GetCategoriesQueryHandler
        (ICategoryRepository CategoryRepository) 
        : IQueryHandler<GetCategoriesQuery, IEnumerable<CategoriesResponse>>
    {
        public async Task<IEnumerable<CategoriesResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productCategories = await CategoryRepository.GetAllAsync(x => x.DeleteDate == null);
            return productCategories.Adapt<IEnumerable<CategoriesResponse>>();
        }
    }
}
