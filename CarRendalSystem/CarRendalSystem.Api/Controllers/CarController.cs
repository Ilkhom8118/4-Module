using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Services;
using CarRendalSystem.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService CarService;

        public CarController(ICarService carService)
        {
            CarService = carService;
        }

        [HttpPost("add")]
        public async Task<Car> AddAsync(CarCreateDto obj)
        {
            return await CarService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await CarService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(CarUpdateDto obj)
        {
            await CarService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<CarGetDto> GetByIdAsync(long id)
        {
            return await CarService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<CarGetDto>> GetAllAsync()
        {
            return await CarService.GetAllAsync();
        }
    }
}
