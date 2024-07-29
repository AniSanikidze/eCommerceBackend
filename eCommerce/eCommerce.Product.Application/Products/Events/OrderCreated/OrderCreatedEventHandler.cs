using eCommerce.Common.EventBus;
using eCommerce.Product.Application.Services;

namespace eCommerce.Product.Application.Products.Events.OrderCreated
{
    internal class OrderCreatedEventHandler(IProductService productService) : IEventHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent @event)
        {
            foreach (var orderItem in @event.Items)
            {
                var isStockAvailable = await productService.IsStockAvailableAsync(orderItem.ProductId, orderItem.Quantity, default);
                if (!isStockAvailable)
                {
                    await productService.HandleInsufficientStockAsync(@event.OrderId, orderItem.ProductId, default);
                    return;
                }
            }
        }
    }
}
