using eCommerce.Order.Domain.Interfaces;
using eCommerce.Order.Domain.Outbox;
using MassTransit;

namespace eCommerce.Order.Application.Common.Idempotence
{
    public abstract class IdempotentConsumerBase<TMessage>(
        IUnitOfWork unitOfWork, 
        IConsumerOutboxMessageRepository consumerMessageRepository)
        : IConsumer<TMessage> where TMessage : class
    {
        public async Task Consume(ConsumeContext<TMessage> context)
        {
            var eventIdProperty = typeof(TMessage).GetProperty("EventId");
            if (eventIdProperty == null)
            {
                //_logger.LogError("EventId property not found on message type {MessageType}", typeof(TMessage));
                throw new InvalidOperationException($"EventId property not found on message type {typeof(TMessage)}");
            }

            var eventId = (Guid)eventIdProperty.GetValue(context.Message);

            var existingMessage = await consumerMessageRepository.GetAsync(m => m.EventId == eventId);

            if (existingMessage != null && existingMessage.Processed)
            {
                //_logger.LogInformation("Event with ID {EventId} has already been processed.", eventId);
                return;
            }

            if (existingMessage == null)
            {
                existingMessage = new ConsumerOutboxMessage
                {
                    Id = Guid.NewGuid(),
                    EventId = eventId,
                    ConsumerType = GetType().Name,
                    OccurredOn = DateTime.Now,
                    Processed = false
                };

                await consumerMessageRepository.AddAsync(existingMessage);
                await unitOfWork.SaveChangesAsync();
            }

            await ProcessMessage(context);

            existingMessage.Processed = true;
            existingMessage.ProcessedOn = DateTime.UtcNow;
            consumerMessageRepository.Update(existingMessage);
            await unitOfWork.SaveChangesAsync();
        }

        protected abstract Task ProcessMessage(ConsumeContext<TMessage> context);
    }
}
