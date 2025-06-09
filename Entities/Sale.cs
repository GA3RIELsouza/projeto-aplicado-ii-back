using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Sale : BranchOwnedEntityBase
    {
        public DateTime SaleDateTime { get; set; }

        public ICollection<SaleItem>? SaleItems { get; set; }

        public static Sale CreateFromDto(CreateSaleDto dto)
        {
            return new()
            {
                BranchId = dto.BranchId,
                SaleDateTime = dto.SaleDateTime,
            };
        }
    }
}
