using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class CreateProductCategoryDto
    {
        public uint CompanyId { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class ProductCategoryDto
    {
        public CompanyDto Company { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        public static ProductCategoryDto FromProductCategory(ProductCategory productCategory)
        {
            return new ProductCategoryDto
            {
                Company = CompanyDto.FromCompany(productCategory.Company ?? new()),
                Description = productCategory.Description
            };
        }
    }
}
