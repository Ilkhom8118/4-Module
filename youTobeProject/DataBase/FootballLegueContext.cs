using Microsoft.EntityFrameworkCore;
using youTobeProject.Domain;

namespace youTobeProject.DataBase;

public class FootballLegueContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballLeague_Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Team> Teams { get; set; }
}
