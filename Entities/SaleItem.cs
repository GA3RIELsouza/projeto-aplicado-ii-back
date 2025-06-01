using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class SaleItem : EntityBase
    {
        public uint SaleId { get; set; }
        public uint ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Sale? Sale { get; set; }
        public virtual Product? Product { get; set; }
    }
}
