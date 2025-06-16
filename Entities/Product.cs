using System.Text;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Product : CompanyOwnedEntityBase, IActivatable
    {
        public string Name { get; set; } = string.Empty;
        public string Ean13BarCode { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
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

        public void GenerateEan13BarCode()
        {
            var brazilEanPrefix = "789";

            var strBuilder = new StringBuilder(brazilEanPrefix);

            var companyIdentifier = this.CompanyId.ToString().PadLeft(6, '0');
            var productIdentifier = this.Id.ToString().PadLeft(3, '0');

            strBuilder.Append(companyIdentifier).Append(productIdentifier);

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < 12; i++)
            {
                int digit = strBuilder[i] - '0';
                if ((i + 1) % 2 == 0) evenSum += digit;
                else oddSum += digit;
            }

            int total = oddSum + (evenSum * 3);
            int nearestTen = (int)Math.Ceiling(total / 10f) * 10;
            int checkDigit = nearestTen - total;

            if (checkDigit == 10) checkDigit = 0;

            strBuilder.Append(checkDigit);

            this.Ean13BarCode = strBuilder.ToString();
        }

        public static Product CreateFromDto(CreateProductDto dto)
        {
            return new()
            {
                Name = dto.Name,
                ImageBase64 = dto.ImageBase64,
                ProductCategoryId = dto.ProductCategoryId,
                UnitarySellingPrice = dto.UnitarySellingPrice,
                UnityOfMeasureId = dto.UnityOfMeasureId,
                MinimalInventoryQuantity = dto.MinimalInventoryQuantity
            };
        }
    }
}
