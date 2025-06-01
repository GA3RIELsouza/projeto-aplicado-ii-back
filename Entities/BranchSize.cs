using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class BranchSize : EntityBase
    {
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Branch>? Branches { get; set; }
    }
}
