using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs;

public class ReviewUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; }
}
