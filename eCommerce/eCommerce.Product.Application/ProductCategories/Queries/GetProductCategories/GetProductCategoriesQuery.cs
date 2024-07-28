using eCommerce.Product.Application.Abstractions;
namespace eCommerce.Product.Application.ProductCategories.Queries.GetProductCategories
{
    public record GetProductCategoriesQuery : IQuery<IEnumerable<ProductCategoriesModelResponse>>;
}
