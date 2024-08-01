using eCommerce.Product.Application.Products.Events.OrderCreated;
using eCommerce.Product.Application.Services;
using eCommerce.Product.Infrastructure.Options;
using eCommerce.Product.Infrastructure.Services;
using eCommerce.Product.Persistence.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Http;
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

                busConfiguration.UsingRabbitMq((context, configurator) =>
                {
                    var rabbitMQOptions = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
                    configurator.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    configurator.ConfigureEndpoints(context);
                });
            });
            services.AddScoped<IAuditService , AuditService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserResolverService , UserResolverService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
