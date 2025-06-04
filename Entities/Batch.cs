using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class Batch : EntityBase
    {
        public uint ProductId { get; set; }
        public DateOnly BatchDate { get; set; }
        public DateOnly ExpirationDate { get; set; }

        public virtual Product? Product { get; set; }

        public ICollection<ProductInInventory>? ProductsInInventory { get; set; }
    }
}
