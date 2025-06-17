using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Entities
{
    public class UnityOfMeasure : EntityBase
    {
        public uint? CompanyId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;

        public Company? Company { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
