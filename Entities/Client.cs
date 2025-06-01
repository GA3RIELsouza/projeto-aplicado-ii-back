using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.ValueObjects;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Client : CompanyOwnedEntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Address? Address { get; set; }

        public virtual ICollection<Sale>? Sales { get; set; }
    }
}
