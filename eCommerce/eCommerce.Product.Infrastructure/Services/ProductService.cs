using eCommerce.Common.Exceptions;
using eCommerce.Product.Application.Services;
using eCommerce.Product.Domain.Aggregates.Products;

namespace eCommerce.Product.Infrastructure.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<bool> IsStockAvailableAsync(Guid productId, int quantity, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(productId, cancellationToken);
            if (product == null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            return product.StockQuantity >= quantity;
        }

        public async Task UpdateProductStockAsync(Guid productId, int quantity, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(productId, cancellationToken);
            if (product == null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            product.SetStockQuantity(product.StockQuantity - quantity);
            productRepository.Update(product);
        }

        public async Task HandleInsufficientStockAsync(Guid orderId, Guid productId, CancellationToken cancellationToken)
        {
            // Publish an event or handle compensation logic for insufficient stock
            var insufficientStockEvent = new InsufficientStockEvent(orderId, productId);
            await _eventPublisher.PublishAsync(insufficientStockEvent);
        }
    }
}
