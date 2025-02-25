using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.DTOs;

public class CarUpdateDto
{
    public long Id { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public DateTime Year { get; set; }
    public decimal PricePerDay { get; set; }
}
