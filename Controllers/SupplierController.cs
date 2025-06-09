using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController(SupplierService supplierService, SupplierProductService supplierProductService) : ControllerBase
    {
        private readonly SupplierService _supplierService = supplierService;
        private readonly SupplierProductService _supplierProductService = supplierProductService;

        [HttpPost]
        public async Task<IActionResult> CreateSupplierAsync([FromBody] CreateSupplerDto dto)
        {
            var response = await _supplierService.CreateSupplierAsync(dto);

            return Ok(response);
        }

        [HttpPost("{id}/toggle")]
        public async Task<IActionResult> ToggleSupplierAsync(uint id)
        {
            var response = await _supplierService.ToggleSupplierAsync(id);

            return Ok(response);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> ListSupplierProductsAsync(uint id)
        {
            var response = await _supplierProductService.ListSupplierProductsAsync(id);

            return Ok(response);
        }

        [HttpDelete("{supplierId}/product/{productId}")]
        public async Task<IActionResult> DeleteSupplierProductAsync(uint supplierId, uint productId)
        {
            await _supplierProductService.DeleteSupplierProductAsync(supplierId, productId);

            return Ok();
        }

        [HttpPost("{supplierId}/product")]
        public async Task<IActionResult> AddProductToSupplierAsync(uint supplierId, [FromBody] CreateSupplierProductDto dto)
        {
            dto.SupplierId = supplierId;
            var response = await _supplierProductService.CreateSupplierProductAsync(dto);

            return Ok(response);
        }

        [HttpGet("{id}/products/does-not-sell")]
        public async Task<IActionResult> ListSupplierProductsDoesNotSellAsync(uint id)
        {
            var response = await _supplierProductService.ListSupplierProductsDoesNotSellAsync(id);

            return Ok(response);
        }
    }
}
