using eCommerce.Common.EventBus.Events;

namespace eCommerce.Product.Application.Products.Events.SufficientStockEvent
{
    public class SufficientStockEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
    }
}
