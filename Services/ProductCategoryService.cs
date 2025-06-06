using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class ProductCategoryService(MainDbContext db,
        IProductCategoryRepository productCategoryRepository,
        IBranchRepository branchRepository,
        ICompanyRepository companyRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<uint> CreateAsync(CreateProductCategoryDto dto)
        {
            var productCategory = ProductCategory.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _productCategoryRepository.AddAsync(productCategory);
            });

            return productCategory.Id;
        }

        public async Task<ProductCategoryDto> GetByIdAsync(uint id)
        {
            var productCategory = await _productCategoryRepository.GetByIdIncludesThrowsIfNullAsync(id, null, pc => pc.Company);

            return ProductCategoryDto.FromProductCategory(productCategory);
        }

        public async Task<List<ProductCategoryDto>> ListProductCategoriesByBranchAsync(uint branchId)
        {
            var branch = await _branchRepository.GetByIdThrowsIfNullAsync(branchId);

            return await ListProductCategoriesByCompanyAsync(branch.CompanyId);
        }

        public async Task<List<ProductCategoryDto>> ListProductCategoriesByCompanyAsync(uint companyId)
        {
            var response = await _productCategoryRepository.ListProductCategoriesByCompanyAsync(companyId);

            return response;
        }
    }
}
