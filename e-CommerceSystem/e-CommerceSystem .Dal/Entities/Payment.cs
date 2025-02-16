using e_CommerceSystem_.Dal.Enums;

namespace e_CommerceSystem_.Dal.Entities;

public class Payment
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public decimal Amount { get; set; }
    public StatusPayment StatusPayment { get; set; }

}
//Payment(ID, OrderId, Amount, Status)