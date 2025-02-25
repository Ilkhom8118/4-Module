using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class CustomerUpdateDtoValidator:AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator(ICustomerRepo customerRepo)
        {
            // ID musbat bo‘lishi kerak
            RuleFor(customer => customer.Id)
                .GreaterThan(0).WithMessage("Customer ID 0 dan katta bo‘lishi kerak.");

            // Name bo‘sh bo‘lmasligi kerak va eng kamida 2 ta harf bo‘lishi kerak
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Ism bo‘sh bo‘lishi mumkin emas.")
                .MinimumLength(2).WithMessage("Ism kamida 2 ta harfdan iborat bo‘lishi kerak.");

            // Email tekshiruvi (Email formati bo‘lishi kerak)
            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email bo‘sh bo‘lishi mumkin emas.")
                .EmailAddress().WithMessage("Noto‘g‘ri email formati.");

            // PhoneNumber bo‘sh bo‘lmasligi va eng kamida 7 ta raqamdan iborat bo‘lishi kerak
            RuleFor(customer => customer.PhoneNumber)
                .NotEmpty().WithMessage("Telefon raqam bo‘sh bo‘lishi mumkin emas.")
                .Matches(@"^(\+998|998)[0-9]{9}$")
                .WithMessage("Telefon raqam O'zbekiston formati bo‘yicha bo‘lishi kerak (+998901234567 yoki 998901234567).");
        }
    }
}
