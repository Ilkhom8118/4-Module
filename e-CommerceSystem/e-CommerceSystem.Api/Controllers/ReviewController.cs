using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/review")]
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
        [HttpGet("getAll")]
        public async Task<ICollection<ReviewDto>> GetAllAsync()
        {
            return await ReviewService.GetAllAsync();
        }
        [HttpGet("getById")]
        public async Task<ReviewDto> GetById(long id)
        {
            return await ReviewService.GetByIdAsync(id);
        }
    }
}
