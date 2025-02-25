﻿using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class CarCreateDtoValidator : AbstractValidator<CarCreateDto>
    {
        public CarCreateDtoValidator(ICarRepo carRepo)
        {
            // Model nomi bo‘sh bo‘lmasligi kerak va eng kamida 2 ta harf bo‘lishi kerak
            RuleFor(car => car.Model)
                .NotEmpty().WithMessage("Model bo‘sh bo‘lishi mumkin emas.")
                .MinimumLength(2).WithMessage("Model nomi kamida 2 ta harfdan iborat bo‘lishi kerak.");

            // Brand nomi bo‘sh bo‘lmasligi kerak va eng kamida 2 ta harf bo‘lishi kerak
            RuleFor(car => car.Brand)
                .NotEmpty().WithMessage("Brand bo‘sh bo‘lishi mumkin emas.")
                .MinimumLength(2).WithMessage("Brand nomi kamida 2 ta harfdan iborat bo‘lishi kerak.");

            RuleFor(car => car.Year)
                .GreaterThan(new DateTime(2010, 1, 1)).WithMessage("Year 2010 yildan katta bo‘lishi kerak.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Year hozirgi yildan katta bo‘lishi mumkin emas.");

            // PricePerDay 0 dan katta bo‘lishi kerak
            RuleFor(car => car.PricePerDay)
                .GreaterThan(0).WithMessage("PricePerDay 0 dan katta bo‘lishi kerak.");
        }
    }
}
