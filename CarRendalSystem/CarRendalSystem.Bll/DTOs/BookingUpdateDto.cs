namespace CarRendalSystem.Bll.DTOs;

public class BookingUpdateDto
{
    public long Id { get; set; }
    public long CarId { get; set; }
    public long CustomerId { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime StartDate { get; set; }
}
