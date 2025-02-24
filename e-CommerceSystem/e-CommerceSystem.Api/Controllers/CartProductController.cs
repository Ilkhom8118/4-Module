using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ICartProductService CartProductService;

        public CartProductController(ICartProductService cartProductService)
        {
            CartProductService = cartProductService;
        }
        [HttpPost("add")]
        public async Task<CartProduct> AddAsync(CartProductCreateDto obj)
        {
            return await CartProductService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long cartId, long productId)
        {
            await CartProductService.DeleteAsync(cartId, productId);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(CartProductUpdateDto obj)
        {
            await CartProductService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<CartProductDto> GetByIdAsync(long cartId, long productId)
        {
            return await CartProductService.GetByIdAsync(cartId, productId);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<CartProductDto>> GetAllAsync()
        {
            return await CartProductService.GetAllAsync();
        }
    }
}
