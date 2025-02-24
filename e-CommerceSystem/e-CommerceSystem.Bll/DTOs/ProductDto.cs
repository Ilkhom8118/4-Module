using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Stock { get; set; }
    public long CategoryId { get; set; }
    public ICollection<CartProductDto> CartProducts { get; set; }
    public ICollection<OrderProductDto> OrderProducts { get; set; }
    public ICollection<ReviewDto> Reviews { get; set; }
}
