namespace e_CommerceSystem_.Dal.Entities;
public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Stock { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<CartProduct> CartProducts { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
//Product(ID, Name, Description, Price, Stock)