using e_CommerceSystem_.Dal.Entities;
using e_CommerceSystem_.Dal.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem_.Dal;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CartProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
    }
}
