using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class SupplierConfiguration : CompanyOwnedEntityBaseConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            base.Configure(builder);

            builder.ToTable("supplier");

            builder.Property(x => x.LegalName)
                .HasColumnName("legal_name")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.BusinessName)
                .HasColumnName("business_name")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Street)
                .HasColumnName("street")
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.Number)
                .HasColumnName("number")
                .HasMaxLength(16)
                .IsRequired(true);

            builder.Property(x => x.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.City)
                .HasColumnName("city")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.State)
                .HasColumnName("state")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Country)
                .HasColumnName("country")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(15)
                .IsRequired(true);

            builder.Property(x => x.TaxId)
                .HasColumnName("tax_id")
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active")
                .IsRequired(true)
                .HasDefaultValue(true);
        }
    }
}
