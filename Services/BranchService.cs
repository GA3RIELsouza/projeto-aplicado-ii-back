using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class BranchService(MainDbContext db, IBranchRepository branchRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly IBranchRepository _branchRepository = branchRepository;

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
    }
}
