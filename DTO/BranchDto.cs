using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class CreateBranchDto
    {
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public uint BranchSizeId { get; set; }
    }

    public class BranchDto
    {
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public uint BranchSizeId { get; set; }
        public bool IsActive { get; set; } = true;

        public static BranchDto FromBranch(Branch branch)
        {
            return new BranchDto
            {
                Street = branch.Street,
                Number = branch.Number,
                Neighborhood = branch.Neighborhood,
                City = branch.City,
                State = branch.State,
                Country = branch.Country,
                BranchSizeId = branch.BranchSizeId,
                IsActive = branch.IsActive
            };
        }
    }
}
