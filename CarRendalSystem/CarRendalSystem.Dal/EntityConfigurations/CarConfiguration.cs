using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRendalSystem.Dal.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Brand).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Model).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Model).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PricePerDay).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.Bookings).WithOne(b => b.Car).HasForeignKey(c => c.CarId);
            builder.HasMany(c => c.Reviews).WithOne(r => r.Car).HasForeignKey(c => c.CarId);
        }
    }
}
