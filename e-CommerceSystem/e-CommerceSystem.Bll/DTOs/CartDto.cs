namespace e_CommerceSystem.Bll.DTOs
{
    public class CartDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public ICollection<CartProductDto> CartProducts { get; set; }
    }
}
