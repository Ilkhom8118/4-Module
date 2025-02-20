namespace e_CommerceSystem.Bll.DTOs
{
    public class CartProductDto
    {
        public long CartId { get; set; }
        public CartDto Cart { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
