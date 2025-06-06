using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController(BranchService branchService) : ControllerBase
    {
        private readonly BranchService _branchService = branchService;

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBranchDto dto)
        {
            var response = await _branchService.CreateAsync(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(uint id)
        {
            var response = await _branchService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> ListBranchProducts(uint id)
        {
            var response = await _branchService.ListBranchProducts(id);

            return Ok(response);
        }
    }
}
