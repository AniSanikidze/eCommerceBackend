using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.ProductCategories.Commands.UpdateProductCategory
{
    public record UpdateProductCategoryCommand(Guid Id, string Name) : ICommand<Guid>;
}