namespace CarRendalSystem.Dal.Entities;

public class Review
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    public long CarId { get; set; }
    public Car Car { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; }
}
