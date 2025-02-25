using CarRendalSystem.Bll.Validators;
using FluentValidation;

namespace CarRendalSystem.Api.Configurations
{
    public static class ValidatorConfiguration
    {
        public static void ConfigureValidator(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<BookingCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<BookingUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<BookingGetDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CarGetDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CarCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CarUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CustomerCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CustomerUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CustomerGetDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PaymentCrateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PaymentGetDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PaymentUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ReviewCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ReviewUpdateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ReviewGetDtoValidator>();
        }
    }
}
