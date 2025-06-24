using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class SupplierService(MainDbContext db,
        ISupplierRepository supplierRepository,
        ICompanyRepository companyRepository,
        IBranchRepository branchRepository,
        ISupplierProductRepository supplierProductRepository,
        IProductInInventoryRepository productInInventoryRepository,
        ISaleItemRepository saleItemRepository,
        AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly ISupplierRepository _supplierRepository = supplierRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;
        private readonly ISupplierProductRepository _supplierProductRepository = supplierProductRepository;
        private readonly IProductInInventoryRepository _productInInventoryRepository = productInInventoryRepository;
        private readonly ISaleItemRepository _saleItemRepository = saleItemRepository;
        private readonly AuthService _authService = authService;

        public async Task<CreateSupplierDto> GetByIdAsync(uint supplierId)
        {
            var supplier = await _supplierRepository.GetByIdThrowsIfNullAsync(supplierId);

            return new()
            {
                LegalName = supplier.LegalName,
                BusinessName = supplier.BusinessName,
                TaxId = supplier.TaxId,
                Street = supplier.Street,
                Number = supplier.Number,
                Neighborhood = supplier.Neighborhood,
                City = supplier.City,
                State = supplier.State,
                Country = supplier.Country,
                Email = supplier.Email,
                Phone = supplier.Phone
            };
        }

        public async Task<uint> CreateSupplierAsync(CreateSupplierDto dto)
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

        public async Task<uint> UpdateAsync(uint id, CreateSupplierDto dto)
        {
            var supplier = await _supplierRepository.GetByIdThrowsIfNullAsync(id);

            supplier.LegalName = dto.LegalName;
            supplier.BusinessName = dto.BusinessName;
            supplier.TaxId = dto.TaxId;
            supplier.Street = dto.Street;
            supplier.Number = dto.Number;
            supplier.Neighborhood = dto.Neighborhood;
            supplier.City = dto.City;
            supplier.State = dto.State;
            supplier.Country = dto.Country;
            supplier.Email = dto.Email;
            supplier.Phone = dto.Phone;

            await _db.RunInTransactionAsync(() =>
            {
                _supplierRepository.Update(supplier);
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

        public async Task DeleteSupplierAsync(uint supplierId)
        {
            var supplier = await _supplierRepository.GetByIdThrowsIfNullAsync(supplierId);

            var loggedBranch = await _authService.GetLoggedBranchAsync();

            var supplierProducts = await _supplierProductRepository.ListBySupplierAsync(loggedBranch.CompanyId, supplierId);
            var productsInInventory = await _productInInventoryRepository.ListBySupplierAsync(supplierId);
            var saleItems = productsInInventory.Where(pii => pii.SaleItemId.HasValue).Select(pii => pii.SaleItem!).ToArray();

            await _db.RunInTransactionAsync(() =>
            {
                _supplierProductRepository.RemoveRange(supplierProducts);
                _productInInventoryRepository.RemoveRange(productsInInventory);
                _saleItemRepository.RemoveRange(saleItems);
                _supplierRepository.Remove(supplier);
            });
        }
    }
}
