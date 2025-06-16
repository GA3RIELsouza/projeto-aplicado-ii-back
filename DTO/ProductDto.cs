using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class ProductDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ean13BarCode { get; set; } = string.Empty;
        public string? ImageBase64 { get; set; }
        public uint ProductCategoryId { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }
        public int MinimalInventoryQuantity { get; set; }

        public static ProductDto FromProduct(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Ean13BarCode = product.Ean13BarCode,
                ImageBase64 = product.ImageBase64,
                ProductCategoryId = product.ProductCategoryId,
                UnitarySellingPrice = product.UnitarySellingPrice,
                UnityOfMeasureId = product.UnityOfMeasureId,
                MinimalInventoryQuantity = product.MinimalInventoryQuantity
            };
        }
    }

    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
        public uint ProductCategoryId { get; set; }
        public string? OtherProductCategory { get; set; }
        public decimal UnitarySellingPrice { get; set; }
        public uint UnityOfMeasureId { get; set; }
        public int MinimalInventoryQuantity { get; set; } = 10;
    }

    public class CompanyProductDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ean13BarCode { get; set; } = string.Empty;
        public string? ImageBase64 { get; set; }
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
        public string? ImageBase64 { get; set; }
    }
}
