using eCommerce.Product.Application.Abstractions;
namespace eCommerce.Product.Application.ProductCategories.Queries.GetCategories
{
    public record GetCategoriesQuery : IQuery<IEnumerable<CategoriesResponse>>;
}
