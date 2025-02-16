using CarRendalSystem.Dal;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Api.Configurations;

public static class DataBaseConfiguration
{
    public static void ConfigurateDataBase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(o =>
        {
            o.UseSqlServer(connectionString);
        });
    }
}
