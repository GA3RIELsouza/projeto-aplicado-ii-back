using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Product : CompanyOwnedEntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public uint ProductCategoryId { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }

        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual UnityOfMeasure? UnityOfMeasure { get; set; }

        public virtual ICollection<SaleItem>? SaleItems { get; set; }
        public virtual ICollection<Batch>? Batches { get; set; }
        public virtual ICollection<ProductInInventory>? ProductsInInventory { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public virtual ICollection<SupplierProduct>? SupplierProducts { get; set; }
    }
}
