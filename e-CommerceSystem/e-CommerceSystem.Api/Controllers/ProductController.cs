using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }
        [HttpPost("add")]
        public async Task<Product> AddAsync(ProductCreateDto obj)
        {
            return await ProductService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await ProductService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(ProductUpdateDto obj)
        {
            await ProductService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<ProductDto> GetByIdAsync(long id)
        {
            return await ProductService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            return await ProductService.GetallAsync();
        }
    }
}
