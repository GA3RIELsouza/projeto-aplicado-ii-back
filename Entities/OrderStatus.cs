using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class OrderStatus : EntityBase
    {
        public string Description { get; set; } = string.Empty;

        public ICollection<Order>? Orders { get; set; }
    }
}
