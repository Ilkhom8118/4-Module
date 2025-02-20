using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface IReviewRepo
{
    Task<Review> AddAsync(Review obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(Review obj);
    Task<Review> GetByIdAsync(long id);
    IQueryable<Review> GetAll();
}