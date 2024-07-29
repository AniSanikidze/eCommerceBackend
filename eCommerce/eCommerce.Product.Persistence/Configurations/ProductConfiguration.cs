using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;

namespace eCommerce.Product.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(350);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();

            builder.Property(x => x.StockQuantity).IsRequired();
            builder.HasMany(p => p.ProductCategories)
                    .WithMany(c => c.Products)
                    .UsingEntity(j => j.ToTable("ProductCategories"));
        }
    }
}
