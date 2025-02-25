using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRendalSystem.Dal.EntityConfigurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.StartDate).IsRequired(true);
        builder.Property(b => b.EndDate).IsRequired(true);
        builder.Property(c => c.TotalCost).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(b => b.Car).WithMany(c => c.Bookings).HasForeignKey(b => b.CarId);
        builder.HasOne(b => b.Customer).WithMany(c => c.Bookings).HasForeignKey(b => b.CustomerId);

        builder.HasMany(b => b.Payments).WithOne(p => p.Booking).HasForeignKey(b => b.BookingId);
    }
}
