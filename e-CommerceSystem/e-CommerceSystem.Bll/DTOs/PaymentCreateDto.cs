using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class PaymentCreateDto
{
    public long? OrderId { get; set; }
    public decimal Amount { get; set; }
    public StatusPayment StatusPayment { get; set; }
}
