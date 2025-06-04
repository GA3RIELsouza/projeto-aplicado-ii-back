using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class CompanyService(MainDbContext db, ICompanyRepository companyRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<uint> CreateAsync(CreateCompanyDto dto)
        {
            var company = Company.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _companyRepository.AddAsync(company);
            });

            return company.Id;
        }

        public async Task<CompanyDto> GetByIdAsync(uint id)
        {
            var company = await _companyRepository.GetByIdThrowsIfNullAsync(id);

            return CompanyDto.FromCompany(company);
        }
    }
}
