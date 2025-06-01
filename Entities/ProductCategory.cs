using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class ProductCategory : CompanyOwnedEntityBase
    {
        public string Descrtiption { get; set; } = string.Empty;

        public virtual ICollection<Product>? Products { get; set; }
    }
}
