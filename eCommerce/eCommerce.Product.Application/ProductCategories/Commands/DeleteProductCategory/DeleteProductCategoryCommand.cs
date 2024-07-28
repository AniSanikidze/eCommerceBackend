using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.ProductCategories.Commands.DeleteProductCategory
{
    public record DeleteProductCategoryCommand(Guid Id) : ICommand;
}