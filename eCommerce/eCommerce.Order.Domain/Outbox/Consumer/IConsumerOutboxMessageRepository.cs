using eCommerce.Order.Domain.Interfaces;

namespace eCommerce.Order.Domain.Outbox
{
    public interface IConsumerOutboxMessageRepository : IRepository<ConsumerOutboxMessage, Guid>
    {
    }
}
