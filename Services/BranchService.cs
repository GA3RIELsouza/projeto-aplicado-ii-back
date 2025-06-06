using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class BranchService(MainDbContext db, IBranchRepository branchRepository, ProductService productService)
    {
        private readonly MainDbContext _db = db;
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly ProductService _productService = productService;

        public async Task<uint> CreateAsync(CreateBranchDto dto)
        {
            var company = Branch.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _branchRepository.AddAsync(company);
            });

            return company.Id;
        }

        public async Task<BranchDto> GetByIdAsync(uint id)
        {
            var branch = await _branchRepository.GetByIdThrowsIfNullAsync(id);

            return BranchDto.FromBranch(branch);
        }

        public async Task<List<CompanyProductDto>> ListBranchProducts(uint branchId)
        {
            var branch = await _branchRepository.GetByIdThrowsIfNullAsync(branchId);

            var response = await _productService.ListCompanyProducts(branch.CompanyId);

            return response;
        }
    }
}
