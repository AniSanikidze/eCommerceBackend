using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.ProductCategories.Commands.CreateProductCategory
{
    public record CreateProductCategoryCommand(string Name) : ICommand<Guid>;
}