using CarRendalSystem.Dal.Enums;

namespace CarRendalSystem.Dal.Entities;

public class Payment
{
    public long Id { get; set; }
    public long BookingId { get; set; }
    public Booking Booking { get; set; }
    public double Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
