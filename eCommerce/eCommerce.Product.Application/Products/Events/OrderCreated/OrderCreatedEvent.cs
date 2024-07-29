using eCommerce.Common.EventBus.Events;

namespace eCommerce.Product.Application.Products.Events.OrderCreated
{
    public class OrderCreatedEvent : IntegrationEvent
    {
       public Guid OrderId { get; set; }
       public List<OrderItem> Items { get; set; }
    }

    public record OrderItem(
        Guid ProductId,
        Guid OrderId, 
        string ProductName,
        int Quantity,
        decimal UnitPrice);
}
