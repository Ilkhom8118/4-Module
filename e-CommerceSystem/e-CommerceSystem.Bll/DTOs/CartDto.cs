namespace e_CommerceSystem.Bll.DTOs
{
    public class CartDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public List<CartProductDto> CartProducts { get; set; } = new List<CartProductDto>();
       

    }
}
