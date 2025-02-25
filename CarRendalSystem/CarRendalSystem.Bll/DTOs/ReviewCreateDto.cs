using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.DTOs;

public class ReviewCreateDto
{
    public long CustomerId { get; set; }
    public long CarId { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; }
}
