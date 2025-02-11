using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repoistory.Services;

public class CommentRepo : ICommentRepo
{
    private readonly MainContext MainContext;

    public CommentRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Comment> AddCommmentAsync(Comment obj)
    {
        await MainContext.Comments.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var remove = await GetByIdAsync(id);
        MainContext.Comments.Remove(remove);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllCommentAsync()
    {
        var comments = await MainContext.Comments.ToListAsync();
        return comments;
    }

    public async Task<Comment> GetByIdAsync(long id)
    {
        var comment = await MainContext.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        if (comment == null)
        {
            throw new Exception("Null");
        }
        return comment;
    }

    public async Task UpdateAsync(Comment obj)
    {
        MainContext.Comments.Update(obj);
        await MainContext.SaveChangesAsync();

    }
}
