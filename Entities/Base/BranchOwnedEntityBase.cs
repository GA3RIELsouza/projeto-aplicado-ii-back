namespace Projeto_Aplicado_II_API.Entities.Base
{
    public class BranchOwnedEntityBase : EntityBase
    {
        public uint BranchId { get; set; }
        
        public virtual Branch? Branch { get; set; }
    }
}
