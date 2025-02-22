using e_CommerceSystem_.Dal.Entities;
using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class UserCreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }
}
