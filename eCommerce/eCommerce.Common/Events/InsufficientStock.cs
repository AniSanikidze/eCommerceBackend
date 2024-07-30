namespace eCommerce.Common.Events
{
    public class InsufficientStock
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
