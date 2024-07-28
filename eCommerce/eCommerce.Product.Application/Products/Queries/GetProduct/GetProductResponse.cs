namespace eCommerce.Product.Application.Products.Queries.GetProduct
{
    public record GetProductResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int? StockQuantity,
        List<ProductCategoryResponse> Categories);
}
