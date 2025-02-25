using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Services;
using CarRendalSystem.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalSystem.Api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService BookingService;

        public BookingController(IBookingService bookingService)
        {
            BookingService = bookingService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] BookingCreateDto obj)
        {
            var result = await BookingService.AddAsync(obj);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await BookingService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(BookingUpdateDto obj)
        {
            await BookingService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<BookingGetDto> GetByIdAsync(long id)
        {
            return await BookingService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<BookingGetDto>> GetAllAsync()
        {
            return await BookingService.GetAllAsync();
        }
    }
}
