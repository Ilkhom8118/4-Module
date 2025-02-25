using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem_.Dal.Entities;

public class Order
{
    public long Id { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime OrderTime { get; set; }
    public Payment Payment { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
//Order(ID, UserId, OrderDate, Status)