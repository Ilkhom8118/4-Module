namespace e_CommerceSystem.Bll.DTOs;

public class OrderCreateDto
{
    public long UserId { get; set; }
    public long PaymentId { get; set; }
    public DateTime OrderTime { get; set; }
}
