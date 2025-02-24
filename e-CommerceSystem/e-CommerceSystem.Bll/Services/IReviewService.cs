using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface IReviewService
{
    Task<Review> AddAsync(ReviewCreateDto obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(ReviewUpdateDto obj);
    Task<ReviewDto> GetByIdAsync(long id);
    Task<ICollection<ReviewDto>> GetAllAsync();
}