using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Repoistory.Services
{
    public interface IReviewRepo
    {
        Task<Review> AddAsync(Review obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(Review obj);
        Task<Review> GetByIdAsync(long id);
        Task<List<Review>> GetAllAsync();
    }
}