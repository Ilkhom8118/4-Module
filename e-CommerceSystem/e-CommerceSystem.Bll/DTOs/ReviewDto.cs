namespace e_CommerceSystem.Bll.DTOs;

public class ReviewDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; }
}
