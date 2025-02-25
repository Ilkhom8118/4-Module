using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.DTOs;

public class CustomerCreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
