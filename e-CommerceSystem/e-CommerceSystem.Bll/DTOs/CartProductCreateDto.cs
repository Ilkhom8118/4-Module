using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs;

public class CartProductCreateDto
{
    public long CartId { get; set; }
    public long ProductId { get; set; }
    public decimal Quantity { get; set; }
}
