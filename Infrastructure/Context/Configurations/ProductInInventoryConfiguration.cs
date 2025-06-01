using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class ProductInInventoryConfiguration : EntityBaseConfiguration<ProductInInventory>
    {
        public override void Configure(EntityTypeBuilder<ProductInInventory> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_in_inventory");

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired(true);

            builder.Property(x => x.BranchId)
                .HasColumnName("branch_id")
                .IsRequired(true);

            builder.Property(x => x.BarCode)
                .HasColumnName("bar_code")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.IsSold)
                .HasColumnName("is_sold")
                .HasDefaultValue(false)
                .IsRequired(true);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Batch)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.BatchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
