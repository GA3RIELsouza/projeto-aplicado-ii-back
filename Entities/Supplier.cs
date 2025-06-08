using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Supplier : CompanyOwnedEntityBase, IActivatable
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Sale>? Sales { get; set; }
        public ICollection<SupplierProduct>? SupplierProducts { get; set; }

        public static Supplier CreateFromDto(CreateSupplerDto dto)
        {
            return new()
            {
                LegalName = dto.LegalName,
                BusinessName = dto.BusinessName,
                TaxId = dto.TaxId,
                Street = dto.Street,
                Number = dto.Number,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                Email = dto.Email,
                Phone = dto.Phone,
                IsActive = true
            };
        }
    }
}
