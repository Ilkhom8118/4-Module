using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Dal.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Dal;

public class MainContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
