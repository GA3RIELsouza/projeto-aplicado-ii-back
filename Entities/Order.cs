using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Order : BranchOwnedEntityBase
    {
        public uint SupplierId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime? DeliveryDateTime { get; set; }
        public uint OrderStatusId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
