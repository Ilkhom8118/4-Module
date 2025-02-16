using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired(false).HasMaxLength(50);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Stock).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        builder.HasMany(p => p.CartProducts).WithOne(c => c.Product).HasForeignKey(p => p.ProductId);
        builder.HasMany(p => p.OrderProducts).WithOne(op => op.Product).HasForeignKey(p => p.ProductId);
        builder.HasMany(p => p.Reviews).WithOne(r => r.Product).HasForeignKey(p => p.ProductId);
    }
}
