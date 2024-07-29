namespace eCommerce.Product.Application.Products.Queries.GetProduct
{
    public record ProductResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int? StockQuantity,
        List<CategoryResponse> ProductCategories);
}
