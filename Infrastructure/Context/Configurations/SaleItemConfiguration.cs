using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class SaleItemConfiguration : EntityBaseConfiguration<SaleItem>
    {
        public override void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("sale_item");

            builder.Property(x => x.SaleId)
                .HasColumnName("sale_id")
                .IsRequired(true);

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired(true);

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .IsRequired(true);

            builder.HasOne(x => x.Sale)
                .WithMany(y => y.SaleItems)
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.SaleItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<SaleItem> builder)
        {
            const int count = 12;
            var defaultSaleItems = new SaleItem[count];

            for (int i = 0; i < count; i++)
            {
                defaultSaleItems[i] = new()
                {
                    Id = (uint)(i + 1),
                    SaleId = (uint)(i + 1),
                    ProductId = (uint)Math.Ceiling((i + 1) / 2m),
                    Quantity = 2
                };
            }

            builder.HasData(defaultSaleItems);
        }
    }
}
