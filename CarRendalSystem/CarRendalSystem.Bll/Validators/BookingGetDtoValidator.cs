using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class BookingGetDtoValidator : AbstractValidator<BookingGetDto>
    {
        public BookingGetDtoValidator(IBookingRepo bookingRepo)
        {
            // ID musbat bo‘lishi kerak
            RuleFor(booking => booking.Id)
                .GreaterThan(0).WithMessage("Booking ID 0 dan katta bo‘lishi kerak.");

            // CarId musbat bo‘lishi kerak
            RuleFor(booking => booking.CarId)
                .GreaterThan(0).WithMessage("Car ID 0 dan katta bo‘lishi kerak.");

            // CustomerId musbat bo‘lishi kerak
            RuleFor(booking => booking.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID 0 dan katta bo‘lishi kerak.");

            // StartDate kelajakda bo‘lishi kerak
            RuleFor(booking => booking.StartDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("StartDate kelajakdagi sana bo‘lishi kerak.");

            // EndDate StartDate dan keyin bo‘lishi kerak
            RuleFor(booking => booking.EndDate)
                .GreaterThan(booking => booking.StartDate)
                .WithMessage("EndDate StartDate dan keyin bo‘lishi kerak.");

            // TotalCost 0 dan katta bo‘lishi kerak
            RuleFor(booking => booking.TotalCost)
                .GreaterThan(0).WithMessage("TotalCost 0 dan katta bo‘lishi kerak.");

            // Customer bo‘sh bo‘lmasligi kerak
            RuleFor(booking => booking.Customer)
                .NotNull().WithMessage("Customer bo‘sh bo‘lishi mumkin emas.");

            // Payments kolleksiyasi bo‘sh bo‘lmasligi yoki null bo‘lmasligi kerak
            RuleFor(booking => booking.Payments)
                .NotNull().WithMessage("Payments bo‘sh bo‘lishi mumkin emas.")
                .Must(p => p.Count > 0).WithMessage("Kamida bitta Payment bo‘lishi kerak.");
        }
    }
}
