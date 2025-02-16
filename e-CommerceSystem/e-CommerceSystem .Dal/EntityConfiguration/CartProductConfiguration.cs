using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration;

public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
{
    public void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        builder.ToTable("CartProduct");
        builder.HasKey(cp => new { cp.ProductId, cp.CartId });
        builder.Property(cp => cp.Quantity).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(cp => cp.Product).WithMany(p => p.CartProducts).HasForeignKey(cp => cp.ProductId);
        builder.HasOne(cp => cp.Cart).WithMany(c => c.CartProducts).HasForeignKey(cp => cp.CartId);
    }
}
