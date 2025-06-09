namespace Projeto_Aplicado_II_API.DTO
{
    public class CreateSupplerDto
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class SupplierDto
    {
        public uint Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class SupplierMiniDto
    {
        public uint Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
    }
}
