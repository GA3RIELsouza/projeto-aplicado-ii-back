using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class ProductInInventory : BranchOwnedEntityBase
    {
        public uint ProductId { get; set; }
        public uint OrderId { get; set; }
        public uint BatchId { get; set; }
        public string BarCode { get; set; } = string.Empty;
        public bool IsSold { get; set; } = false;

        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Batch? Batch { get; set; }
    }
}
