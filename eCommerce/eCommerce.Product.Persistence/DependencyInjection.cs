using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Aggregates.Products;
using eCommerce.Product.Domain.Interfaces;
using eCommerce.Product.Persistence.Context;
using eCommerce.Product.Persistence.Repositories;
using eCommerce.Product.Persistence.Sieve;
using eCommerce.Product.Persistence.Sieve.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace eCommerce.Product.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ProductDbContext>());

            services.AddScoped<ISieveProcessor, eCommerceProductSieveProcessor>();
            services.AddScoped<ISieveCustomFilterMethods, ProductSieveCustomFilter>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
