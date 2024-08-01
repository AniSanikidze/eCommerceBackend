using eCommerce.Order.Domain.Interfaces;
using eCommerce.Order.Domain.Orders;
using eCommerce.Order.Domain.Outbox;
using eCommerce.Order.Domain.Outbox.Publisher;
using eCommerce.Order.Infrastructure.Services;
using eCommerce.Order.Persistence.Context;
using eCommerce.Order.Persistence.Context.Interceptor;
using eCommerce.Order.Persistence.Interfaces;
using eCommerce.Order.Persistence.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Order.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<OutboxSaveChangesInterceptor>(); // Register the interceptor
            services.AddDbContext<OrderDbContext>((serviceProvider, options) =>
            {
                var interceptor = serviceProvider.GetRequiredService<OutboxSaveChangesInterceptor>();
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                       .AddInterceptors(interceptor); // Add the interceptor to the DbContext options
            });
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<OrderDbContext>());


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPublisherOutboxMessageRepository, PublisherOutboxMessageRepository>();
            services.AddScoped<IConsumerOutboxMessageRepository, ConsumerOutboxMessageRepository>();
            services.AddScoped<IAuditService, AuditService>();

            return services;
        }
    }
}
