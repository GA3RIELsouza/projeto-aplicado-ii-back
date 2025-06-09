using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ProductService productService, UnityOfMeasureService unityOfMeasureService, SupplierProductService supplierProductService) : ControllerBase
    {
        private readonly ProductService _productService = productService;
        private readonly UnityOfMeasureService _unityOfMeasureService = unityOfMeasureService;
        private readonly SupplierProductService _supplierProductService = supplierProductService;

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductDto dto)
        {
            var response = await _productService.CreateAsync(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(uint id)
        {
            var response = await _productService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(uint id, [FromBody] CreateProductDto dto)
        {
            var response = await _productService.UpdateAsync(id, dto);

            return Ok(response);
        }

        [HttpPost("{id}/toggle")]
        public async Task<IActionResult> ToggleProductAsync(uint id)
        {
            var response = await _productService.ToggleProductAsync(id);

            return Ok(response);
        }

        [HttpGet("unities-of-measure")]
        public async Task<IActionResult> ListUnitiesOfMeasureAsync()
        {
            var response = await _unityOfMeasureService.ListUnitiesOfMeasure();

            return Ok(response);
        }

        [HttpGet("{id}/suppliers")]
        public async Task <IActionResult> ListProductSuppliersAsync(uint id)
        {
            var response = await _supplierProductService.ListProductSuppliersAsync(id);

            return Ok(response);
        }
    }
}
