using e_CommerceSystem_.Dal.Entities;
using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem.Bll.DTOs
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public decimal Amount { get; set; }
        public StatusPayment StatusPayment { get; set; }
    }
}
