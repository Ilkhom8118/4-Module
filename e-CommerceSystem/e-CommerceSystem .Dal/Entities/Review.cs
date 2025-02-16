namespace e_CommerceSystem_.Dal.Entities;

public class Review
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; }
}
//Review(ID, UserId, ProductId, Rating, Comment)