using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand;
}
