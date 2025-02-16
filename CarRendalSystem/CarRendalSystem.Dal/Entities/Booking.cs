namespace CarRendalSystem.Dal.Entities;

public class Booking
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    public long CarId { get; set; }
    public Car Car { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
