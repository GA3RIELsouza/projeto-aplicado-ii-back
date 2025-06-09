using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController(SaleService saleService) : ControllerBase
    {
        private readonly SaleService _saleService = saleService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(uint id)
        {
            var response = await _saleService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(uint id, CreateSaleDto dto)
        {
            var response = await _saleService.UpdateAsync(id, dto);

            return Ok(response);
        }

        [HttpGet("{saleId}/items")]
        public async Task<IActionResult> ListSaleItemsAsync(uint saleId)
        {
            var response = await _saleService.ListSaleItemsAsync(saleId);

            return Ok(response);
        }

        [HttpGet("{saleId}/items/not-included")]
        public async Task<IActionResult> ListSaleItemsNotIncludedAsync(uint saleId)
        {
            var response = await _saleService.ListSaleItemsNotIncludedAsync(saleId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranchSaleAsync([FromBody] CreateSaleDto dto)
        {
            var response = await _saleService.CreateSaleAsync(dto);

            return Ok(response);
        }

        [HttpPost("{saleId}/item")]
        public async Task<IActionResult> AddItemToSaleAsync(uint saleId, [FromBody] CreateSaleItemDto dto)
        {
            dto.SaleId = saleId;
            var response = await _saleService.AddItemToSaleAsync(dto);

            return Ok(response);
        }

        [HttpDelete("{saleId}/item/{saleItemId}")]
        public async Task<IActionResult> DeleteSaleItemAsync(uint saleId, uint saleItemId)
        {
            await _saleService.DeleteSaleItemAsync(saleId, saleItemId);

            return Ok();
        }

        [HttpDelete("{saleId}")]
        public async Task<IActionResult> DeleteSaleAsync(uint saleId)
        {
            await _saleService.DeleteSaleAsync(saleId);

            return Ok();
        }

        [HttpGet("{saleId}/item/{saleItemId}")]
        public async Task<IActionResult> GetSaleItemAsync(uint saleId, uint saleItemId)
        {
            var response = await _saleService.GetSaleItemAsync(saleId, saleItemId);

            return Ok(response);
        }

        [HttpPut("{saleId}/item/{saleItemId}")]
        public async Task<IActionResult> UpdateSaleItemAsync(uint saleId, uint saleItemId, CreateSaleItemDto dto)
        {
            var response = await _saleService.UpdateSaleItemAsync(saleId, saleItemId, dto);

            return Ok(response);
        }
    }
}
