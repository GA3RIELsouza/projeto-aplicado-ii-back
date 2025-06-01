using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class CompanyConfiguration : EntityBaseConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.ToTable("company");

            builder.Property(x => x.LegalName)
                .HasColumnName("legal_name")
                .HasMaxLength(128)
                .HasComment("Razão Social")
                .IsRequired(true);

            builder.Property(x => x.BusinessName)
                .HasColumnName("business_name")
                .HasMaxLength(128)
                .HasComment("Nome Fantasia")
                .IsRequired(true);

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(32)
                .IsRequired(true);

            builder.Property(x => x.TaxId)
                .HasColumnName("tax_id")
                .HasMaxLength(64)
                .HasComment("CNPJ")
                .IsRequired(true);

            builder.HasIndex(x => x.TaxId);

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired(true);

            builder.HasMany(x => x.Branches)
                .WithOne()
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasMany(x => x.Products)
                .WithOne()
                .HasForeignKey(cp => cp.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
