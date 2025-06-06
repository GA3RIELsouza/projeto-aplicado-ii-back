namespace Projeto_Aplicado_II_API.DTO
{
    public class ProductInInventoryDto
    {
        public ProductMiniDto Product { get; set; } = null!;
        public int MinimalInventoryQuantity { get; set; }
        public int QuantityInInventory { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
