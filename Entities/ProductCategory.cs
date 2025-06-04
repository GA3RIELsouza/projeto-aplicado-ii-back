using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class ProductCategory : CompanyOwnedEntityBase
    {
        public string Description { get; set; } = string.Empty;

        public ICollection<Product>? Products { get; set; }
    }
}
