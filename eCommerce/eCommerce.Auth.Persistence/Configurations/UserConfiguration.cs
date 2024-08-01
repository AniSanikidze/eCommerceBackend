using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using eCommerce.Auth.Domain.User;

namespace eCommerce.Auth.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.PersonalNumber).IsRequired().HasMaxLength(11);
        }
    }
}
