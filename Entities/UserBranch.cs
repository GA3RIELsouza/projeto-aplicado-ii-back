using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class UserBranch : BranchOwnedEntityBase
    {
        public uint UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
