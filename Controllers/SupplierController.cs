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
    }
}
