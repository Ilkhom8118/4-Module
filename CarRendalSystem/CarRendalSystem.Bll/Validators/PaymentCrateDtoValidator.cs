using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class PaymentCrateDtoValidator:AbstractValidator<PaymentCreateDto>
    {
        public PaymentCrateDtoValidator(IPaymentRepo paymentRepo)
        {
            // Booking ID musbat bo‘lishi kerak
            RuleFor(payment => payment.BookingId)
                .GreaterThan(0).WithMessage("Booking ID 0 dan katta bo‘lishi kerak.");

            // Amount musbat bo‘lishi kerak
            RuleFor(payment => payment.Amount)
                .GreaterThan(0).WithMessage("To‘lov summasi 0 dan katta bo‘lishi kerak.");

            // PaymentStatus noto‘g‘ri bo‘lmasligi kerak
            RuleFor(payment => payment.PaymentStatus)
                .IsInEnum().WithMessage("Noto‘g‘ri to‘lov holati kiritildi.");
        }
    }
}
