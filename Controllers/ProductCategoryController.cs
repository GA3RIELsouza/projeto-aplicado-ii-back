using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController(ProductCategoryService productCategoryService) : ControllerBase
    {
        private readonly ProductCategoryService _productCategoryService = productCategoryService;

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductCategoryDto dto)
        {
            var response = await _productCategoryService.CreateAsync(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(uint id)
        {
            var response = await _productCategoryService.GetByIdAsync(id);

            return Ok(response);
        }
    }
}
