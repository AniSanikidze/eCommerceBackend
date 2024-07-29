namespace eCommerce.Product.Application.Services
{
    public interface IProductService
    {
        Task<bool> IsStockAvailableAsync(Guid productId, int quantity, CancellationToken cancellationToken);
        Task UpdateProductStockAsync(Guid productId, int quantity, CancellationToken cancellationToken);
        Task HandleInsufficientStockAsync(Guid orderId, Guid productId, CancellationToken cancellationToken);
    }
}