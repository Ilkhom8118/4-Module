using Instagram.Dal.Entities;

namespace Instagram.Bll.DTOs;

public class CommentGetDto
{
    public long CommentId { get; set; }
    public string Body { get; set; }
    public DateTime CreateTime { get; set; }
    public long AccountId { get; set; }
    public long PostId { get; set; }
    public long? ParentComentId { get; set; }
    public List<CommentGetDto> Replies { get; set; }
}
