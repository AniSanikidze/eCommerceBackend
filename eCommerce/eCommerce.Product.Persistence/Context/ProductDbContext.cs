using eCommerce.Product.Domain.Aggregates.ProductCategories;
using Microsoft.EntityFrameworkCore;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;

namespace eCommerce.Product.Persistence.Context
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        }
    }
}
