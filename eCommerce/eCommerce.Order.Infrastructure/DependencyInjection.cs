using eCommerce.Order.Application.Orders.Events.InsufficientStock;
using eCommerce.Order.Domain.Carts;
using eCommerce.Order.Infrastructure.Options;
using eCommerce.Order.Infrastructure.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace eCommerce.Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));

            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.AddConsumer<InsufficientStockConsumer>();
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
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration.GetConnectionString("Redis");
            });

            services.AddScoped<ICartRepository, RedisCartRepository>();

            return services;
        }
    }
}
