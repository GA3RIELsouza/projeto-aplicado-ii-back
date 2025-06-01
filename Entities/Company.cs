using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Company : EntityBase, IActivatable
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Branch>? Branches { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
