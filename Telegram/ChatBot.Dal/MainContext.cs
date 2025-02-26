using ChatBot.Dal.Entities;
using ChatBot.Dal.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Dal;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=DESKTOP-JA0B9SA\\SQLEXPRESS; Database=CarRendalSystem; User Id=sa; Password=1; TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

}
