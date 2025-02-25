using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Validators
{
    public class BookingCreateDtoValidator : AbstractValidator<BookingCreateDto>
    {
        public BookingCreateDtoValidator(IBookingRepo bookingRepo)
        {
            // CarId musbat bo‘lishi kerak
            RuleFor(booking => booking.CarId)
                .GreaterThan(0).WithMessage("Car ID 0 dan katta bo‘lishi kerak.");

            // CustomerId musbat bo‘lishi kerak
            RuleFor(booking => booking.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID 0 dan katta bo‘lishi kerak.");

            // StartDate kelajakda bo‘lishi kerak
            RuleFor(booking => booking.StartDate)
                .GreaterThan(DateTime.UtcNow.AddMinutes(-5)).WithMessage("StartDate kelajakdagi sana bo'lishi kerak.");

            // EndDate StartDate dan keyin bo‘lishi kerak
            RuleFor(booking => booking.EndDate)
                .GreaterThan(booking => booking.StartDate).WithMessage("EndDate StartDate dan keyin bo'lishi kerak.");

            // TotalCost 0 dan katta bo‘lishi kerak
            RuleFor(booking => booking.TotalCost)
                .GreaterThan(0).WithMessage("TotalCost 0 dan katta bo‘lishi kerak.");
        }
    }
}
