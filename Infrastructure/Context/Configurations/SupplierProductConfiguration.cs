using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class SupplierProductConfiguration : EntityBaseConfiguration<SupplierProduct>
    {
        public override void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {
            base.Configure(builder);

            builder.ToTable("supplier_product");

            builder.Property(x => x.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired(true);

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired(true);

            builder.Property(x => x.UnitaryPrice)
                .HasColumnName("unitary_price")
                .HasPrecision(8, 2)
                .IsRequired(true);

            builder.HasOne(x => x.Supplier)
                .WithMany(y => y.SupplierProducts)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.SupplierProducts)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasIndex(x => new { x.SupplierId, x.ProductId })
                .IsUnique(true);
        }

        private protected override void SetData(EntityTypeBuilder<SupplierProduct> builder)
        {
            const int count = 6;
            var defaultSuppliersProducts = new SupplierProduct[count];

            for (int i = 0; i < count; i++)
            {
                defaultSuppliersProducts[i] = new()
                {
                    Id = (uint)(i + 1),
                    SupplierId = (uint)(i + 1),
                    ProductId = (uint)(i + 1)
                };
            }

            builder.HasData(defaultSuppliersProducts);
        }
    }
}
