using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Product : CompanyOwnedEntityBase, IActivatable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public uint ProductCategoryId { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }
        public int MinimalStockQuantity { get; set; } = 10;
        public bool IsActive { get; set; } = true;

        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual UnityOfMeasure? UnityOfMeasure { get; set; }

        public ICollection<SaleItem>? SaleItems { get; set; }
        public ICollection<Batch>? Batches { get; set; }
        public ICollection<ProductInInventory>? ProductsInInventory { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<SupplierProduct>? SupplierProducts { get; set; }

        public static Product CreateFromDto(CreateProductDto dto)
        {
            return new()
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                ProductCategoryId = dto.ProductCategoryId,
                UnitarySellingPrice = dto.UnitarySellingPrice,
                UnityOfMeasureId = dto.UnityOfMeasureId
            };
        }
    }
}
