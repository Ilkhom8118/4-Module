using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService CartService;

        public CartController(ICartService cartService)
        {
            CartService = cartService;
        }
        [HttpPost("add")]
        public async Task<Cart> AddAsync(CartCreateDto obj)
        {
            return await CartService.Addasync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await CartService.DeleteAsync(id);
        }
        [HttpGet("getbyId")]
        public async Task<CartDto> GetByIdAsync(long id)
        {
            return await CartService.GetByIdAsync(id);
        }
        [HttpGet("getall")]
        public async Task<ICollection<CartDto>> GetAllAsync()
        {
            return await CartService.GetAllAsync();
        }
    }
}
