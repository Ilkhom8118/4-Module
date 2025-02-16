namespace e_CommerceSystem_.Dal.Entities;

public class Cart
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public ICollection<CartProduct> CartProducts { get; set; }

}
