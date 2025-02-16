using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Role).IsRequired();
        builder.HasMany(u => u.Carts).WithOne(c => c.User).HasForeignKey(u => u.UserId);
        builder.HasMany(u => u.Reviews).WithOne(r => r.User).HasForeignKey(u => u.UserId);
        builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(u => u.UserId);
    }
}
