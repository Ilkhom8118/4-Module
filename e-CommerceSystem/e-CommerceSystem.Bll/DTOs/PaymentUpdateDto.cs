using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs;

public class PaymentUpdateDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public decimal Amount { get; set; }
    public StatusPayment StatusPayment { get; set; }
}
