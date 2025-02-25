using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.DTOs;

public class CarCreateDto
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public DateTime Year { get; set; }
    public decimal PricePerDay { get; set; }

}
