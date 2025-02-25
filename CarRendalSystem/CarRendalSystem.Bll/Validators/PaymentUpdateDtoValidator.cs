using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class PaymentUpdateDtoValidator : AbstractValidator<PaymentUpdateDto>
    {
        public PaymentUpdateDtoValidator(IPaymentRepo paymentRepo)
        {
            // ID musbat bo‘lishi kerak
            RuleFor(payment => payment.Id)
                .GreaterThan(0).WithMessage("Payment ID 0 dan katta bo‘lishi kerak.");

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
