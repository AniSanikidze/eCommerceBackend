using eCommerce.Order.Domain.Interfaces;
using eCommerce.Order.Domain.Outbox.Publisher;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace eCommerce.Order.Infrastructure.Outbox
{
    public class OutboxMessageProcessor : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<OutboxMessageProcessor> _logger;

        public OutboxMessageProcessor(IServiceProvider serviceProvider,
            ILogger<OutboxMessageProcessor> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Outbox Message Processor is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Outbox processor worker running at :{0}", DateTime.Now);

                await ProcessOutboxMessages(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

            _logger.LogInformation("Outbox Message Processor is stopping.");
        }

        private async Task ProcessOutboxMessages(CancellationToken stoppingToken)
        {

            using (var scope = _serviceProvider.CreateScope())
            {
                var outboxMeessageRepository = scope.ServiceProvider.GetRequiredService<IPublisherOutboxMessageRepository>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var publishEndpoint = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();
                var unprocessedMessages = await outboxMeessageRepository.GetAllAsync(x => !x.Processed);

                foreach (var outboxMessage in unprocessedMessages)
                {
                    var eventType = Type.GetType(outboxMessage.EventType);
                    var eventData = JsonConvert.DeserializeObject(outboxMessage.Payload, eventType);

                    try
                    {
                        await publishEndpoint.Publish(eventData, eventType, stoppingToken);
                        outboxMessage.Processed = true; 
                        await unitOfWork.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception("მოხდა შეცდომა ივენთის დამუშავებისას");
                    }
                }
            }
        }
    }
}