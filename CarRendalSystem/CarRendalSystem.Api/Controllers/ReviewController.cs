using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Services;
using CarRendalSystem.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService ReviewService;

        public ReviewController(IReviewService reviewService)
        {
            ReviewService = reviewService;
        }
        [HttpPost("add")]
        public async Task<Review> AddAsync(ReviewCreateDto obj)
        {
            return await ReviewService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await ReviewService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(ReviewUpdateDto obj)
        {
            await ReviewService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<ReviewGetDto> GetByIdAsync(long id)
        {
            return await ReviewService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<ReviewGetDto>> GetAllAsync()
        {
            return await ReviewService.GetAllAsync();
        }
    }
}
