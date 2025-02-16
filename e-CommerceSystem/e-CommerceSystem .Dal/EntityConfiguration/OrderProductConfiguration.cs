using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");
            builder.HasKey(op => new { op.OrderId, op.ProductId });
            builder.Property(op => op.Quantity).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(op => op.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(op => op.Product).WithMany(p => p.OrderProducts).HasForeignKey(op => op.ProductId);
            builder.HasOne(op => op.Order).WithMany(p => p.OrderProducts).HasForeignKey(op => op.OrderId);
        }
    }
}
