namespace Projeto_Aplicado_II_API.Entities.Base
{
    public class CompanyOwnedEntityBase : EntityBase
    {
        public uint CompanyId { get; set; }
        
        public virtual Company? Company { get; set; }
    }
}
