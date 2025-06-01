using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;
using Projeto_Aplicado_II_API.ValueObjects;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Branch : CompanyOwnedEntityBase, IActivatable
    {
        public Address Address { get; set; } = null!;
        public uint BranchSizeId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual BranchSize? BranchSize { get; set; }

        public virtual ICollection<UserBranch>? UserBranches { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
