using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using eCommerce.Auth.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Auth.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(new()
            {
                Id = Guid.NewGuid(),
                Name = Roles.Admin,
                NormalizedName = Roles.Admin.ToUpper()

            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = Roles.Customer,
                NormalizedName = Roles.Customer.ToUpper(),
            });
        }
    }
}
