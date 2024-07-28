using eCommerce.Product.Application.Abstractions;

namespace eCommerce.Product.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        List<Guid> ProductCategoryIds) : ICommand<Guid>;
}
