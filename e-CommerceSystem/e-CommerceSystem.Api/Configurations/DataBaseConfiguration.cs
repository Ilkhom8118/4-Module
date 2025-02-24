using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using e_CommerceSystem_.Dal;

namespace e_CommerceSystem.Api.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void ConfigureDataBase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

            builder.Services.AddDbContext<MainContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}


