using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Sale : BranchOwnedEntityBase
    {
        public uint SupplierId { get; set; }
        public uint? ClientId { get; set; }

        public Supplier? Supplier { get; set; }
        public Client? Client { get; set; }

        public ICollection<SaleItem>? SaleItems { get; set; }
    }
}
