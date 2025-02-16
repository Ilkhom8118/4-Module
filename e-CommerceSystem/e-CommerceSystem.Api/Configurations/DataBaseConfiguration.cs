using e_CommerceSystem_.Dal;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Api.Configurations
{
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
}
