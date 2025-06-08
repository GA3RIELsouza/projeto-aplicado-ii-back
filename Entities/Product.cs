using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;
using System.Text;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Product : CompanyOwnedEntityBase, IActivatable
    {
        public string Name { get; set; } = string.Empty;
        public string Ean13BarCode { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public uint ProductCategoryId { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }
        public int MinimalInventoryQuantity { get; set; } = 10;
        public bool IsActive { get; set; } = true;

        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual UnityOfMeasure? UnityOfMeasure { get; set; }

        public ICollection<SaleItem>? SaleItems { get; set; }
        public ICollection<ProductInInventory>? ProductsInInventory { get; set; }
        public ICollection<SupplierProduct>? SupplierProducts { get; set; }

        public static Product CreateFromDto(CreateProductDto dto)
        {
            return new()
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                ProductCategoryId = dto.ProductCategoryId,
                UnitarySellingPrice = dto.UnitarySellingPrice,
                UnityOfMeasureId = dto.UnityOfMeasureId,
                MinimalInventoryQuantity = dto.MinimalInventoryQuantity
            };
        }
    }
}
