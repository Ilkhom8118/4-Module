using Microsoft.EntityFrameworkCore;
using youTobeProject.Domain;

namespace youTobeProject.DataBase;

public class FootballLegueContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-JA0B9SA\\SQLEXPRESS;Database=FootballLeague_Db;User Id=sa;Password=1;TrustServerCertificate=True;");
    }


    public DbSet<League> Leagues { get; set; }
    public DbSet<Team> Teams { get; set; }
}
