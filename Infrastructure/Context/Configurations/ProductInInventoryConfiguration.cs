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

            builder.Property(x => x.OrderId)
                .HasColumnName("order_id")
                .IsRequired(true);

            builder.Property(x => x.BatchId)
                .HasColumnName("batch_id")
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

            builder.HasOne(x => x.Branch)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Order)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Batch)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.BatchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<ProductInInventory> builder)
        {
            const int count = 60;
            var defaultProductsInInventory = new ProductInInventory[count];

            for (int i = 0; i < count; i++)
            {
                defaultProductsInInventory[i] = new()
                {
                    Id = (uint)(i + 1),
                    ProductId = (uint)((i / 10) + 1),
                    BranchId = 1,
                    OrderId = (uint)((i / 10) + 1),
                    BatchId = (uint)((i / 10) + 1),
                    BarCode = $"123456789012{i + 1}",
                    IsSold = false,
                };
            }

            builder.HasData(defaultProductsInInventory);
        }
    }
}
