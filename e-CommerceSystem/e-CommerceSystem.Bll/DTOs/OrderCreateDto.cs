using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class OrderCreateDto
{
    public long UserId { get; set; }
    public StatusOrder StatusOrder { get; set; }
    public DateTime OrderTime { get; set; }
}
