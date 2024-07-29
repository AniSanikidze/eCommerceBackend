using eCommerce.Order.Domain.Interfaces;
using eCommerce.Order.Domain.Orders;
using eCommerce.Order.Infrastructure.Services;
using eCommerce.Order.Persistence.Context;
using eCommerce.Order.Persistence.Interfaces;
using eCommerce.Order.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Order.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<OrderDbContext>());

            //services.AddScoped<ISieveProcessor, eCommerceProductSieveProcessor>();
            //services.AddScoped<ISieveCustomFilterMethods, ProductSieveCustomFilter>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuditService, AuditService>();

            return services;
        }
    }
}
