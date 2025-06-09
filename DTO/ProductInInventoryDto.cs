namespace Projeto_Aplicado_II_API.DTO
{
    public class ProductInInventoryDto
    {
        public ProductMiniDto Product { get; set; } = null!;
        public int MinimalInventoryQuantity { get; set; }
        public int QuantityInInventory { get; set; }
    }

    public class AdjustProductInventoryDto
    {
        public uint BranchId { get; set; }
        public uint ProductId { get; set; }
        public uint SupplierId { get; set; }
        public int Quantity { get; set; }
        public DateOnly ManufacturingDate { get; set; }
    }
}
