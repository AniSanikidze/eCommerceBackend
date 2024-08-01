using eCommerce.Order.Domain.Interfaces;

namespace eCommerce.Order.Domain.Outbox.Publisher
{
    public interface IPublisherOutboxMessageRepository : IRepository<PublisherOutboxMessage, Guid>
    {
    }
}
