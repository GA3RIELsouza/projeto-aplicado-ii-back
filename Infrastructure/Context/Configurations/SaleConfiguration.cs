using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class SaleConfiguration : BranchOwnedEntityBaseConfiguration<Sale>
    {
        public override void Configure(EntityTypeBuilder<Sale> builder)
        {
            base.Configure(builder);

            builder.ToTable("sale");

            builder.Property(x => x.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired(true);

            builder.Property(x => x.ClientId)
                .HasColumnName("client_id")
                .IsRequired(false);

            builder.HasOne(x => x.Supplier)
                .WithMany(y => y.Sales)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Client)
                .WithMany(y => y.Sales)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(x => x.SaleItems)
                .WithOne(y => y.Sale)
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
