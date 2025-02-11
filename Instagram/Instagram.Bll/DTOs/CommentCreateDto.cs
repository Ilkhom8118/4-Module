namespace Instagram.Bll.DTOs;

public class CommentCreateDto
{
    public string Body { get; set; }
    public long AccountId { get; set; }
    public long PostId { get; set; }
    public long? ParentComentId { get; set; }
}
