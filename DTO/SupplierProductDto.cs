namespace Projeto_Aplicado_II_API.DTO
{
    public class SupplierProductDto : ProductMiniDto
    {
        public decimal UnitaryPrice { get; set; }
    }

    public class CreateSupplierProductDto
    {
        public uint SupplierId { get; set; }
        public uint ProductId { get; set; }
        public decimal UnitaryPrice { get; set; }
    }
}
