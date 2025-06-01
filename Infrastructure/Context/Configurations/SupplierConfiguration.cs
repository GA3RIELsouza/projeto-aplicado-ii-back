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

            builder.OwnsOne(x => x.Address, DEFAULT_ADDRESS_BUILDER);

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

            builder.HasMany(x => x.Orders)
                .WithOne(y => y.Supplier)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasMany(x => x.Sales)
                .WithOne(y => y.Supplier)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
