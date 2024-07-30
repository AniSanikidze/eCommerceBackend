using MassTransit;

namespace eCommerce.Product.Application.Services
{
    public interface IProductService
    {
        Task<bool> IsStockAvailableAsync(Guid productId, int quantity);
        Task UpdateProductStockAsync(Guid productId, int quantity);
        Task HandleInsufficientStockAsync(Guid orderId, Guid productId, IPublishEndpoint publishEndpoint);
    }
}