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
    }
}
