using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Branch : CompanyOwnedEntityBase, IActivatable
    {
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public uint BranchSizeId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual BranchSize? BranchSize { get; set; }

        public ICollection<ProductInInventory>? ProductsInInventory { get; set; }
        public ICollection<UserBranch>? UserBranches { get; set; }

        public static Branch CreateFromDto(CreateBranchDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Street = dto.Street,
                Number = dto.Number,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                BranchSizeId = dto.BranchSizeId,
                IsActive = true
            };
        }
    }
}
