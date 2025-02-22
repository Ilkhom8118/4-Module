using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.DTOs;

public class BookingGetDto
{
    public long Id { get; set; }
    public long CarId { get; set; }
    public CarGetDto Car { get; set; }
    public long CustomerId { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime StartDate { get; set; }
    public CustomerGetDto Customer { get; set; }
    public ICollection<PaymentGetDto> Payments { get; set; }
}
