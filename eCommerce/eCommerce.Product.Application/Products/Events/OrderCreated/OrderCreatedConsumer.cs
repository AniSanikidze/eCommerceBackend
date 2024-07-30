using OrderCreatedEvent = eCommerce.Common.Events.OrderCreated;
using eCommerce.Product.Application.Services;
using MassTransit;

namespace eCommerce.Product.Application.Products.Events.OrderCreated
{
    public class OrderCreatedConsumer(IProductService productService, IPublishEndpoint publishEndpoint) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var @event = context.Message;
            foreach (var orderItem in @event.OrderItems)
            {
                var isStockAvailable = await productService.IsStockAvailableAsync(orderItem.ProductId, orderItem.Quantity);
                if (!isStockAvailable)
                {
                    await productService.HandleInsufficientStockAsync(@event.Id, orderItem.ProductId, publishEndpoint);
                    return;
                }
            }
        }
    }
}
