using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRendalSystem.Dal.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(150);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(13);

            builder.HasMany(c => c.Bookings).WithOne(b => b.Customer).HasForeignKey(c => c.CustomerId);
            builder.HasMany(c => c.Reviews).WithOne(r => r.Customer).HasForeignKey(c => c.CustomerId);
        }
    }
}