namespace e_CommerceSystem_.Dal.Entities;

public class OrderProduct
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
//OrderItem(OrderId, ProductId, Quantity, Price)