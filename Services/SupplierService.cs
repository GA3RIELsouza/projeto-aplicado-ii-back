using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class SupplierService(MainDbContext db, ISupplierRepository supplierRepository, ICompanyRepository companyRepository, IBranchRepository branchRepository, AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly ISupplierRepository _supplierRepository = supplierRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly AuthService _authService = authService;

        public async Task<uint> CreateSupplierAsync(CreateSupplerDto dto)
        {
            var supplier = Supplier.CreateFromDto(dto);

            var branch = await _authService.GetLoggedBranchAsync();

            supplier.CompanyId = branch.CompanyId;

            await _db.RunInTransactionAsync(async () =>
            {
                await _supplierRepository.AddAsync(supplier);
            });

            return supplier.Id;
        }

        public async Task<List<SupplierDto>> ListBranchSuppliersAsync(uint branchId)
        {
            var branch = await _branchRepository.GetByIdThrowsIfNullAsync(branchId);

            return await ListCompanySuppliersAsync(branch.CompanyId);
        }

        public async Task<List<SupplierDto>> ListCompanySuppliersAsync(uint companyId)
        {
            await _companyRepository.ThrowIfNotExists(c => c.Id == companyId);

            return await _supplierRepository.ListCompanySuppliers(companyId);
        }

        public async Task<bool> ToggleSupplierAsync(uint supplierId)
        {
            var supplier = await _supplierRepository.GetByIdThrowsIfNullAsync(supplierId);

            supplier.IsActive = !supplier.IsActive;

            await _db.RunInTransactionAsync(() =>
            {
                _supplierRepository.Update(supplier);
            });

            return supplier.IsActive;
        }
    }
}
