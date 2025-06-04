using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class CompanyDto
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;

        public static CompanyDto FromCompany(Company company)
        {
            return new CompanyDto
            {
                LegalName = company.LegalName,
                BusinessName = company.BusinessName,
                Phone = company.Phone,
                TaxId = company.TaxId
            };
        }
    }

    public class CreateCompanyDto
    {
        public string LegalName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string TaxId { get; set; } = string.Empty;
    }
}
