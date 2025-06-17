using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Company : EntityBase, IActivatable
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Branch>? Branches { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public ICollection<UnityOfMeasure>? UnitiesOfMeasure { get; set; }

        public static Company CreateFromDto(CreateCompanyDto dto)
        {
            return new()
            {
                LegalName = dto.LegalName,
                BusinessName = dto.BusinessName,
                Phone = dto.Phone,
                TaxId = dto.TaxId,
                IsActive = true
            };
        }
    }
}
