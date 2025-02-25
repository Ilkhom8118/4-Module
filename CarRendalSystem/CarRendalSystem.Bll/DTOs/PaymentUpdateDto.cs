using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Dal.Enums;

namespace CarRendalSystem.Bll.DTOs;

public class PaymentUpdateDto
{
    public long Id { get; set; }
    public long BookingId { get; set; }
    public double Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
