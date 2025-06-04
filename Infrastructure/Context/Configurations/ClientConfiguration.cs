using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class ClientConfiguration : CompanyOwnedEntityBaseConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.ToTable("client");

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(x => x.TaxId)
                .HasColumnName("tax_id")
                .HasMaxLength(14)
                .HasComment("CPF")
                .IsRequired(true);

            builder.Property(x => x.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(254)
                .IsRequired(false);

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.OwnsOne(x => x.Address, DEFAULT_NULLABLE_ADDRESS_BUILDER);
        }
    }
}
