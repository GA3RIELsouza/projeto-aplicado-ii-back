using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class ProductInInventory : BranchOwnedEntityBase
    {
        public uint ProductId { get; set; }
        public DateOnly ManufacturingDate { get; set; }
        public uint? SaleItemId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual SaleItem? SaleItem { get; set; }
    }
}
