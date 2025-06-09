using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class ProductInInventoryController(ProductInInventoryService productInInventoryService) : ControllerBase
    {
        private readonly ProductInInventoryService _productInInventoryService = productInInventoryService;

        [HttpPost("product/{productId}/adjust")]
        public async Task<IActionResult> AdjustBranchInventoryAsync(uint productId, [FromBody] AdjustProductInventoryDto dto)
        {
            dto.ProductId = productId;
            var response = await _productInInventoryService.AdjustProductInventoryAsync(dto);

            return Ok(response);
        }
    }
}
