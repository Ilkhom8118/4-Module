using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators;

public class ReviewUpdateValidator:AbstractValidator<ReviewUpdateDto>
{
    public ReviewUpdateValidator(IReviewRepo reviewRepo)
    {
        RuleFor(review => review.Id)
              .GreaterThan(0).WithMessage("Review ID 0 dan katta bo‘lishi kerak.");

        RuleFor(review => review.UserId)
            .GreaterThan(0).WithMessage("User ID 0 dan katta bo‘lishi kerak.");

        RuleFor(review => review.ProductId)
            .GreaterThan(0).WithMessage("Product ID 0 dan katta bo‘lishi kerak.");

        RuleFor(review => review.Rating)
            .InclusiveBetween(1, 5).WithMessage("Reyting 1 dan 5 gacha bo‘lishi kerak.");

        RuleFor(review => review.Comment)
            .NotEmpty().WithMessage("Fikr-mulohaza (comment) bo‘sh bo‘lishi mumkin emas.")
            .MaximumLength(500).WithMessage("Fikr-mulohaza maksimal 500 ta belgidan iborat bo‘lishi kerak.");
    }
}
