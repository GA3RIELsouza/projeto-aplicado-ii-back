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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(uint id)
        {
            var response = await _supplierService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplierAsync([FromBody] CreateSupplierDto dto)
        {
            var response = await _supplierService.CreateSupplierAsync(dto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(uint id, [FromBody] CreateSupplierDto dto)
        {
            var response = await _supplierService.UpdateAsync(id, dto);

            return Ok(response);
        }

        [HttpGet("{supplierId}/product/{productId}")]
        public async Task<IActionResult> GetSupplierProductAsync(uint supplierId, uint productId)
        {
            var response = await _supplierProductService.GetByIdAsync(supplierId, productId);

            return Ok(response);
        }

        [HttpPut("{supplierId}/product/{productId}")]
        public async Task<IActionResult> UpdateSupplierProductAsync(uint supplierId, uint productId, CreateSupplierProductDto dto)
        {
            var response = await _supplierProductService.UpdateAsync(supplierId, productId, dto);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplierAsync(uint id)
        {
            await _supplierService.DeleteSupplierAsync(id);

            return Ok();
        }
    }
}
