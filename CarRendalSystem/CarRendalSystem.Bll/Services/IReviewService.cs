using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.Services
{
    public interface IReviewService
    {
        Task<Review> AddAsync(ReviewCreateDto obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(ReviewUpdateDto obj);
        Task<ReviewGetDto> GetByIdAsync(long id);
        Task<ICollection<ReviewGetDto>> GetAllAsync();
    }
}