using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }
    public List<CartDto> Carts { get; set; }
    public List<OrderDto> Orders { get; set; }
    public List<ReviewDto> Reviews { get; set; }
}
