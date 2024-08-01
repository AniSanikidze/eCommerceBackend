using eCommerce.Order.Application.Services;
using eCommerce.Order.Domain.Outbox.Publisher;

namespace eCommerce.Order.Infrastructure.Services
{
    public class OutboxService(IPublisherOutboxMessageRepository outboxMessageRepository) : IOutboxService
    {
        public Task AddIntegrationE { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
