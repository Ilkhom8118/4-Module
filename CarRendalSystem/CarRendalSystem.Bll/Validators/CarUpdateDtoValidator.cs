using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators;

public class CarUpdateDtoValidator : AbstractValidator<CarUpdateDto>
{
    public CarUpdateDtoValidator(ICarRepo carRepo)
    {
        // ID musbat bo‘lishi kerak (update qilish uchun mavjud bo‘lishi kerak)
        RuleFor(car => car.Id)
            .GreaterThan(0).WithMessage("Car ID 0 dan katta bo‘lishi kerak.");

        // Model nomi bo‘sh bo‘lmasligi kerak va eng kamida 2 ta harf bo‘lishi kerak
        RuleFor(car => car.Model)
            .NotEmpty().WithMessage("Model bo‘sh bo‘lishi mumkin emas.")
            .MinimumLength(2).WithMessage("Model nomi kamida 2 ta harfdan iborat bo‘lishi kerak.");

        // Brand nomi bo‘sh bo‘lmasligi kerak va eng kamida 2 ta harf bo‘lishi kerak
        RuleFor(car => car.Brand)
            .NotEmpty().WithMessage("Brand bo‘sh bo‘lishi mumkin emas.")
            .MinimumLength(2).WithMessage("Brand nomi kamida 2 ta harfdan iborat bo‘lishi kerak.");

        // Year 1886 yildan keyingi bo‘lishi va kelajakdan oldingi bo‘lishi kerak
        RuleFor(car => car.Year)
            .GreaterThan(new DateTime(2010, 1, 1)).WithMessage("Year 2010 yildan katta bo‘lishi kerak.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Year hozirgi yildan katta bo‘lishi mumkin emas.");

        // PricePerDay 0 dan katta bo‘lishi kerak
        RuleFor(car => car.PricePerDay)
            .GreaterThan(0).WithMessage("PricePerDay 0 dan katta bo‘lishi kerak.");
    }
}



