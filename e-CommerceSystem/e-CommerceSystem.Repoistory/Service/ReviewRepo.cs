using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class ReviewRepo : IReviewRepo
{
    private MainContext MainContext;

    public ReviewRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }
    public async Task<Review> AddAsync(Review obj)
    {
        await MainContext.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var byId = await GetByIdAsync(id);
        MainContext.Remove(byId);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<Review> GetAll()
    {
        var all = MainContext.Reviews;
        return all;
    }

    public async Task<Review> GetByIdAsync(long id)
    {
        var byId = await MainContext.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        if (byId == null)
        {
            throw new Exception($"Review not found : {id}");
        }
        return byId;
    }

    public async Task UpdateAsync(Review obj)
    {
        var byId = await GetByIdAsync(obj.Id);
        MainContext.Update(byId);
        await MainContext.SaveChangesAsync();
    }
}
