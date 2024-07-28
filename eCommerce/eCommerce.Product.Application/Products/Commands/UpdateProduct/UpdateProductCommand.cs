using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        List<Guid> ProductCategoryIds) : ICommand<Guid>;
}
