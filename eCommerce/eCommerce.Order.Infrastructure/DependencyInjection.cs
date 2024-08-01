using eCommerce.Common.Events;
using eCommerce.Order.Application.Orders.Events.InsufficientStock;
using eCommerce.Order.Domain.Carts;
using eCommerce.Order.Domain.Outbox;
using eCommerce.Order.Infrastructure.Options;
using eCommerce.Order.Infrastructure.Outbox;
using eCommerce.Order.Infrastructure.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace eCommerce.Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));
            //services.AddScoped<StockValidationFailedConsumer>();
            //services.AddScoped<IConsumer<StockValidationFailed>, StockValidationFailedConsumer>();

            //services.Decorate<IConsumer<StockValidationFailed>, IdempotentConsumer<StockValidationFailed>>();

            services.AddMassTransit(busConfiguration =>
            {
                //busConfiguration.AddConsumer<IdempotentConsumer<StockValidationFailedConsumer>>();
                busConfiguration.AddConsumer<StockValidationFailedConsumer>();

                busConfiguration.SetKebabCaseEndpointNameFormatter();
                busConfiguration.UsingRabbitMq((context, configurator) =>
                {
                    var rabbitMQOptions = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
                    configurator.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    configurator.ConfigureEndpoints(context);

                    //configurator.Publish<OrderCreatedEvent>(x =>
                    //{
                    //    //x.ExchangeType = "direct"; // default, allows any valid exchange type
                    //});
                    //configurator.ConfigureEndpoints(context);
                });
            });
            //services.Decorate<IConsumer<StockValidationFailed>, IdempotentConsumer<StockValidationFailed>>();

            //services.AddScoped<IConsumer<StockValidationFailed>>(provider =>
            //{
            //    var consumer = provider.GetRequiredService<StockValidationFailedConsumer>();
            //    var consumerRepository = provider.GetRequiredService<IConsumerOutboxMessageRepository>();
            //    var logger = provider.GetRequiredService<ILogger<IdempotentConsumer<StockValidationFailed>>>();

            //    return new IdempotentConsumer<StockValidationFailed>(consumer, consumerRepository, logger);
            //});
            services.AddHostedService<OutboxMessageProcessor>();
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration.GetConnectionString("Redis");
            });

            services.AddScoped<ICartRepository, RedisCartRepository>();

            return services;
        }
    }
}
