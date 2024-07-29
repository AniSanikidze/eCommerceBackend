using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.ProductCategories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(Guid Id) : ICommand;
}