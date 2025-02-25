using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class ReviewGetDtoValidator:AbstractValidator<ReviewGetDto>
    {
        public ReviewGetDtoValidator(IReviewRepo reviewRepo)
        {
            RuleFor(review => review.Id)
           .GreaterThan(0).WithMessage("Review ID 0 dan katta bo‘lishi kerak.");

            // Customer ID musbat bo‘lishi kerak
            RuleFor(review => review.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID 0 dan katta bo‘lishi kerak.");

            // Car ID musbat bo‘lishi kerak
            RuleFor(review => review.CarId)
                .GreaterThan(0).WithMessage("Car ID 0 dan katta bo‘lishi kerak.");

            // Rating 0 va 5 oralig‘ida bo‘lishi kerak
            RuleFor(review => review.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating 0 va 5 orasida bo‘lishi kerak.");

            // Comment bo‘sh bo‘lmasligi va uzunligi 500 belgidan oshmasligi kerak
            RuleFor(review => review.Comment)
                .NotEmpty().WithMessage("Comment bo‘sh bo‘lishi mumkin emas.")
                .MaximumLength(500).WithMessage("Comment 500 belgidan oshmasligi kerak.");
        }
    }
}

