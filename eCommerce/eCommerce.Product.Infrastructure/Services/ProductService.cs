using eCommerce.Common.Events;
using eCommerce.Common.Exceptions;
using eCommerce.Product.Application.Services;
using eCommerce.Product.Domain.Aggregates.Products;
using MassTransit;

namespace eCommerce.Product.Infrastructure.Services
{
    public class ProductService(
        IProductRepository productRepository) : IProductService
    {
        public async Task<bool> IsStockAvailableAsync(Guid productId, int quantity)
        {
            var product = await productRepository.GetAsync(x => x.Id == productId && x.DeleteDate == null);
            if (product == null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            return product.StockQuantity >= quantity;
        }

        public async Task UpdateProductStockAsync(Guid productId, int quantity)
        {
            var product = await productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            product.SetStockQuantity(product.StockQuantity - quantity);
            productRepository.Update(product);
        }

        public async Task HandleInsufficientStockAsync(Guid orderId, Guid productId, IPublishEndpoint publishEndpoint)
        {
            await publishEndpoint.Publish(new StockValidationFailed() { 
                OrderId = orderId,
                ProductId = productId,
                EventId = Guid.NewGuid()
            });
        }
    }
}
