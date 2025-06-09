using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(CompanyService companyService,
        ProductService productService) : ControllerBase
    {
        private readonly CompanyService _companyService = companyService;
        private readonly ProductService _productService = productService;

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

        [HttpGet("{id}/products")]
        public async Task<IActionResult> ListCompanyProductsAsync(uint id)
        {
            var response = await _productService.ListCompanyProductsAsync(id);

            return Ok(response);
        }
    }
}
