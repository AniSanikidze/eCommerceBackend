using eCommerce.Common.Events.Base;

namespace eCommerce.Common.Events
{
    public class StockValidationFailed : IntegrationEvent
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
