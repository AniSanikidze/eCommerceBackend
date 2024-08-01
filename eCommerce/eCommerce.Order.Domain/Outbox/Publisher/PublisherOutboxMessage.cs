using eCommerce.Order.Domain.Base;

namespace eCommerce.Order.Domain.Outbox.Publisher
{
    public class PublisherOutboxMessage : Entity<Guid>
    {
        public string EventType { get; set; }
        public string Payload { get; set; }
        public DateTime OccurredOn { get; set; }
        public bool Processed { get; set; }
        public DateTime? ProcessedOn { get; set; }
    }
}
