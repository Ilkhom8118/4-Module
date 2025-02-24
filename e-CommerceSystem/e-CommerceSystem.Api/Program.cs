
using e_CommerceSystem.Api.Configurations;
using e_CommerceSystem.Bll.MappingProfiles;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem.Repoistory.Service;


namespace e_CommerceSystem.Api
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

            builder.ConfigureDataBase();
            builder.ConfigureValidator();

            builder.Services.AddAutoMapper(typeof(UserProfiles), typeof(ProductProfiles), typeof(CategoryProfiles),
                typeof(CartProfiles), typeof(CartProductProfiles), typeof(OrderProfiles), typeof(PaymentProfiles), typeof(ReviewProfiles));

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartProductService, CartProductService>();
            builder.Services.AddScoped<ICartProductRepo, CartProductRepo>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderProductRepo, OrderProductRepo>();
            builder.Services.AddScoped<IOrderProductService, OrderProductService>();
            builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
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
