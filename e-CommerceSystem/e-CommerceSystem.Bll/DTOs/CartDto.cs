using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs
{
    public class CartDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
