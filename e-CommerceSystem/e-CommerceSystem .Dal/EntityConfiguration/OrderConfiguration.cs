using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderTime).IsRequired();
            builder.Property(o => o.OrderStatus).IsRequired();
            builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Payment>(p => p.OrderId);
            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
            builder.HasMany(o => o.OrderProducts).WithOne(cp => cp.Order).HasForeignKey(o => o.OrderId);
        }
    }
}
