using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(CompanyService companyService) : ControllerBase
    {
        private readonly CompanyService _companyService = companyService;

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCompanyDto dto)
        {
            var response = await _companyService.CreateAsync(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(uint id)
        {
            var response = await _companyService.GetByIdAsync(id);

            return Ok(response);
        }
    }
}
