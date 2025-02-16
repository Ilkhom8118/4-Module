using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRendalSystem.Dal.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");
        builder.HasKey(p => p.Id);
        builder.Property(c => c.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(p => p.Booking).WithMany(b => b.Payments).HasForeignKey(p => p.BookingId);
        builder.HasOne(p => p.Booking).WithMany(b => b.Payments).HasForeignKey(p => p.BookingId).OnDelete(DeleteBehavior.Cascade);
    }
}
