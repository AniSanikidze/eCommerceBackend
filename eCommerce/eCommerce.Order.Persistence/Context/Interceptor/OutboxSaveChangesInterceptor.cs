using eCommerce.Order.Domain.Outbox;
using eCommerce.Order.Domain.Outbox.Publisher;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace eCommerce.Order.Persistence.Context.Interceptor
{
    public class OutboxSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context as OrderDbContext;
            if (context == null) return result;

            await HandleOutboxMessagesAsync(context, cancellationToken);
            return result;
        }

        private async Task HandleOutboxMessagesAsync(OrderDbContext context, CancellationToken cancellationToken)
        {
            var publishedEvents = context.PublishedEvents;

            foreach (var @event in publishedEvents)
            {
                var outboxMessage = new PublisherOutboxMessage
                {
                    Id = Guid.NewGuid(),
                    EventType = @event.GetType().AssemblyQualifiedName,
                    Payload = JsonConvert.SerializeObject(@event),
                    OccurredOn = DateTime.UtcNow,
                    Processed = false
                };

                await context.PublisherOutboxMessages.AddAsync(outboxMessage, cancellationToken);
            }
        }
    }
}
