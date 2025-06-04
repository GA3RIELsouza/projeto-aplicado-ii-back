using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;
using Projeto_Aplicado_II_API.ValueObjects;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Supplier : CompanyOwnedEntityBase, IActivatable
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public Address Address { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public ICollection<SupplierProduct>? SupplierProducts { get; set; }
    }
}
