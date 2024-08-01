using eCommerce.Order.Domain.Outbox.Publisher;
using eCommerce.Order.Persistence.Context;
using eCommerce.Order.Persistence.Repositories.Base;

namespace eCommerce.Order.Persistence.Repositories
{
    public class PublisherOutboxMessageRepository : Repository<PublisherOutboxMessage, Guid>, IPublisherOutboxMessageRepository
    {
        public PublisherOutboxMessageRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
