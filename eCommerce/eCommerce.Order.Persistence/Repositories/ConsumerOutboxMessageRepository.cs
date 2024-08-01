using eCommerce.Order.Domain.Outbox;
using eCommerce.Order.Persistence.Context;
using eCommerce.Order.Persistence.Repositories.Base;

namespace eCommerce.Order.Persistence.Repositories
{
    public class ConsumerOutboxMessageRepository : Repository<ConsumerOutboxMessage, Guid>, IConsumerOutboxMessageRepository
    {
        public ConsumerOutboxMessageRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
