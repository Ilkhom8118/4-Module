namespace e_CommerceSystem.Api.Configurations;
using e_CommerceSystem.Bll.Validators;
using FluentValidation;
public static class ValidatorConfiguration
{
    public static void ConfigureValidator(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UserUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ProductUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CategoryDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CategoryUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CartCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CartDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CartProductDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CartProductCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CartProductUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<OrderUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<OrderCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<OrderDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<OrderProductDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<OrderProductCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<OrderProductUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<PaymentUpdateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<PaymentCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<PaymentDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ReviewDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ReviewCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ReviewUpdateValidator>();
    }
}
