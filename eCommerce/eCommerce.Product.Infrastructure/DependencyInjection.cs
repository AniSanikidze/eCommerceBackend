using eCommerce.Product.Application.Products.Events.OrderCreated;
using eCommerce.Product.Application.Services;
using eCommerce.Product.Infrastructure.Options;
using eCommerce.Product.Infrastructure.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace eCommerce.Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));

            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.SetKebabCaseEndpointNameFormatter();
                busConfiguration.AddConsumer<OrderCreatedConsumer>();
                //var asb = typeof(OrderCreatedEventHandler).Assembly;

                busConfiguration.UsingRabbitMq((context, configurator) =>
                {
                    var rabbitMQOptions = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
                    configurator.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    configurator.ConfigureEndpoints(context);
                    //configurator.ReceiveEndpoint("order-created-queue", e =>
                    //{
                    //    e.Consumer<AConsumer>(context);
                    //});
                });
            });

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
