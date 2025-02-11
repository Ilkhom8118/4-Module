using Instagram.Bll.DTOs;

namespace Instagram.Bll.Services;

public interface ICommentService
{
    Task<CommentGetDto> AddAsync(CommentCreateDto obj);
    Task<CommentGetDto> GetByIdAsync(long id);
    Task<List<CommentGetDto>> GetAllAsync();
    Task DeleteAsync(long id);
    Task UpdateAsync(CommentGetDto obj);
}