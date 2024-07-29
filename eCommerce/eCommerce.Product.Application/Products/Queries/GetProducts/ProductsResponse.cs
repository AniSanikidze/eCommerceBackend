namespace eCommerce.Product.Application.Products.Queries.GetProducts
{
    public record ProductsResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price);
}
