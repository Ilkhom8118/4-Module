using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs;

public class OrderDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PaymentId { get; set; }
    public DateTime OrderTime { get; set; }
    public ICollection<OrderProductDto> OrderProducts { get; set; }
}
