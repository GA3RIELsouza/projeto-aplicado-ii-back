namespace Projeto_Aplicado_II_API.DTO
{
    public class UserBranchesDto
    {
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public BranchSizeDto BranchSize { get; set; } = null!;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
