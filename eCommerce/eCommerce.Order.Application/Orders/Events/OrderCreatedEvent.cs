using eCommerce.Order.Application.Common.EventBus.Events;

namespace eCommerce.Order.Application.Orders.Events
{
    public class OrderCreatedEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid CustomerId { get; }
        //public List<OrderItemDto> OrderItems { get; }
    }
}
