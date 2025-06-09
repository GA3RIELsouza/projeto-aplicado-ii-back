using Microsoft.AspNetCore.Mvc;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController(BranchService branchService,
        ProductCategoryService productCategoryService,
        ProductInInventoryService productInInventoryService,
        SupplierService supplierService,
        SaleService saleService) : ControllerBase
    {
        private readonly BranchService _branchService = branchService;
        private readonly ProductCategoryService _productCategoryService = productCategoryService;
        private readonly ProductInInventoryService _productInInventoryService = productInInventoryService;
        private readonly SupplierService _supplierService = supplierService;
        private readonly SaleService _saleService = saleService;

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

        [HttpGet("{id}/product-categories")]
        public async Task<IActionResult> ListProductCategoriesByBranchAsync(uint id)
        {
            var response = await _productCategoryService.ListProductCategoriesByBranchAsync(id);

            return Ok(response);
        }

        [HttpGet("{id}/inventory")]
        public async Task<IActionResult> ListBranchInventoryAsync(uint id)
        {
            var response = await _productInInventoryService.ListBranchInventory(id);

            return Ok(response);
        }

        [HttpGet("{id}/suppliers")]
        public async Task<IActionResult> ListBranchSuppliersAsync(uint id)
        {
            var response = await _supplierService.ListBranchSuppliersAsync(id);

            return Ok(response);
        }

        [HttpGet("{id}/sales")]
        public async Task<IActionResult> ListBranchSalesAsync(uint id)
        {
            var response = await _saleService.ListBranchSalesAsync(id);

            return Ok(response);
        }
    }
}
