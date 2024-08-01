using eCommerce.Order.Domain.Base;

namespace eCommerce.Order.Domain.Outbox
{
    public class ConsumerOutboxMessage : Entity<Guid>
    {
        public Guid EventId { get; set; }
        public string ConsumerType { get; set; }
        public DateTime OccurredOn { get; set; }
        public bool Processed { get; set; }
        public DateTime? ProcessedOn { get; set; }
    }
}
