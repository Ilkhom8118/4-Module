using e_CommerceSystem_.Dal.Entities;
using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }
    public ICollection<OrderDto> Orders { get; set; }
    public ICollection<ReviewDto> Reviews { get; set; }
}
