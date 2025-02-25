using CarRendalSystem.Api.Configurations;
using CarRendalSystem.Bll.MappingProfile;
using CarRendalSystem.Bll.Services;
using CarRendalSystem.Repoistory.Services;

namespace CarRendalSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.ConfigurateDataBase();
            builder.ConfigureValidator();
            

            builder.Services.AddAutoMapper(typeof(BookingProfiles), typeof(CarProfiles),
                typeof(CustomerProfiles), typeof(PaymentProfiles), typeof(ReviewProfiles));

            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarRepo, CarRepo>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
