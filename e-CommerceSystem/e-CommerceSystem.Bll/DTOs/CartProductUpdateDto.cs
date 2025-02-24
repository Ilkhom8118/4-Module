namespace e_CommerceSystem.Bll.DTOs;

public class CartProductUpdateDto
{
    public long CartId { get; set; }
    public long ProductId { get; set; }
    public decimal Quantity { get; set; }
}
