namespace eCommerce.Product.Application.Products.Models
{
    public record ProductRequestModel(
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        List<Guid> CategoryIds);
}
