using Instagram.Dal.Entities;

namespace Instagram.Repoistory.Services;

public interface ICommentRepo
{
    Task<Comment> AddCommmentAsync(Comment obj);
    Task<List<Comment>> GetAllCommentAsync();
    Task<Comment> GetByIdAsync(long id);
    Task DeleteAsync(long id);
    Task UpdateAsync(Comment obj);
    Task<bool> CommentExistsAsync(long id);
}