using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class OrderItem : EntityBase
    {
        public uint OrderId { get; set; }
        public uint ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
