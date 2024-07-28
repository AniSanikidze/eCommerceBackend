using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Aggregates.Products;
using eCommerce.Product.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Product.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            return services;
        }
    }
}
