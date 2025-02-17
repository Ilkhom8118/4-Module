using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem_.Dal.Entities;
public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }
    public Cart Carts { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
//User(ID, Name, Email, Role)