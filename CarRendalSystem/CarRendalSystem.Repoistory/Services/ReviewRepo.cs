using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Dal;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Repoistory.Services
{
    public class ReviewRepo: IReviewRepo
    {
        private MainContext MainContext;

        public ReviewRepo(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Review> AddAsync(Review obj)
        {
            await MainContext.Reviews.AddAsync(obj);
            await MainContext.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteAsync(long id)
        {
            var byId = await GetByIdAsync(id);
            MainContext.Remove(byId);
            await MainContext.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await MainContext.Reviews.ToListAsync();
        }

        public async Task<Review> GetByIdAsync(long id)
        {
            var obj = await MainContext.Reviews.FirstOrDefaultAsync(b => b.Id == id);
            if (obj == null)
            {
                throw new Exception($"Not found Id : {id}");
            }
            return obj;
        }

        public async Task UpdateAsync(Review obj)
        {
            var byId = GetByIdAsync(obj.Id);
            MainContext.Update(obj);
            await MainContext.SaveChangesAsync();
        }
    }
}
