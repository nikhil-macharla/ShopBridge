using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBridge.Data.Core.DbConstants;
using ShopBridge.Services.Core.Models;

namespace ShopBridge.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableConstants.User);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Username).HasColumnName("username");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.GivenName).HasColumnName("given_name");
            builder.Property(x => x.Surname).HasColumnName("surname");
            builder.Property(x => x.Role).HasColumnName("role");
        }
    }
}
