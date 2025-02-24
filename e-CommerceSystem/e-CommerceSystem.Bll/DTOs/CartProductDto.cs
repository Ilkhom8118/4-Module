namespace e_CommerceSystem.Bll.DTOs
{
    public class CartProductDto
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
