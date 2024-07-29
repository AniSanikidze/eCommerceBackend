using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderEntity = eCommerce.Order.Domain.Orders.Order;

namespace eCommerce.Order.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.UpdatedBy).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();

            builder.HasMany(p => p.OrderItems).WithOne().HasForeignKey(x => x.OrderId);
        }
    }
}
