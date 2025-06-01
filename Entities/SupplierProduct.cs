using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class SupplierProduct : CompanyOwnedEntityBase
    {
        public uint SupplierId { get; set; }
        public uint ProductId { get; set; }
        public decimal UnitaryPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual Product? Product { get; set; }
        public virtual UnityOfMeasure? UnityOfMeasure { get; set; }
    }
}
