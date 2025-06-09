namespace Projeto_Aplicado_II_API.DTO
{
    public class CreateSaleDto
    {
        public uint BranchId { get; set; }
        public DateTime SaleDateTime { get; set; }
    }

    public class SaleDto
    {
        public uint Id { get; set; }
        public DateTime SaleDateTime { get; set; }
        public decimal SaleTotal { get; set; }
    }

    public class SaleItemDto
    {
        public uint Id { get; set; }
        public ProductMiniDto Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal ItemSaleTotal { get; set; }
    }

    public class CreateSaleItemDto
    {
        public uint SaleId { get; set; }
        public uint ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
