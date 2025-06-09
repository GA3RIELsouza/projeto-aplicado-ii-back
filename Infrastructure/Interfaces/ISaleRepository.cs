using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task<List<SaleDto>> ListBranchSalesAsync(uint branchId);
    }
}
