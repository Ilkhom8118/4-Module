using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs;

public class OrderUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime OrderTime { get; set; }
}
