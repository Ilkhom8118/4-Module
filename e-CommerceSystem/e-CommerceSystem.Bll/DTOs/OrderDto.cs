using e_CommerceSystem_.Dal.Entities;
using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class OrderDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime OrderTime { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
