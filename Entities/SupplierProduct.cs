using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class SupplierProduct : EntityBase
    {
        public uint SupplierId { get; set; }
        public uint ProductId { get; set; }
        public decimal UnitaryPrice { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual Product? Product { get; set; }

        public static SupplierProduct CreateFromDto(CreateSupplierProductDto dto)
        {
            return new()
            {
                SupplierId = dto.SupplierId,
                ProductId = dto.ProductId,
                UnitaryPrice = dto.UnitaryPrice
            };
        }
    }
}
