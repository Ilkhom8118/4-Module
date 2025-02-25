using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRendalSystem.Dal.EntityConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Review");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Rating).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(r => r.Comment).IsRequired(false).HasMaxLength(250);

        builder.HasOne(b => b.Car).WithMany(c => c.Reviews).HasForeignKey(b => b.CarId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(b => b.Customer).WithMany(c => c.Reviews).HasForeignKey(b => b.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
