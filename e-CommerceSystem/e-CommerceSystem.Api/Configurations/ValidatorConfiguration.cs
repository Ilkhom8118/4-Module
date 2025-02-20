namespace e_CommerceSystem.Api.Configurations;
using e_CommerceSystem.Bll.DTOs;
using FluentValidation;
public static class ValidatorConfiguration
{
    public static void ConfigureValidator(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDto>();
    }
}
