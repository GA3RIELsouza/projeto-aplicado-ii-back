using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Ean13BarCode { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public CreateProductCategoryDto? ProductCategory { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public UnityOfMeasureDto? UnityOfMeasure { get; set; }

        public static ProductDto FromProduct(Product product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Ean13BarCode = product.Ean13BarCode,
                ImageUrl = product.ImageUrl,
                ProductCategory = product.ProductCategory != null ? new CreateProductCategoryDto { Description = product.ProductCategory.Description } : null,
                UnitarySellingPrice = product.UnitarySellingPrice,
                UnityOfMeasure = product.UnityOfMeasure != null ? new UnityOfMeasureDto { Description = product.UnityOfMeasure.Description } : null
            };
        }
    }

    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public uint ProductCategoryId { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }
        public int MinimalInventoryQuantity { get; set; } = 10;
    }

    public class CompanyProductDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ean13BarCode { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public CreateProductCategoryDto? ProductCategory { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public UnityOfMeasureDto? UnityOfMeasure { get; set; }
        public int MinimalInventoryQuantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ProductMiniDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
