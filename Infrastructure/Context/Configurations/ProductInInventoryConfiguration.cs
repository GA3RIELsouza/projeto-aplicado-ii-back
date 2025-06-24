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

            builder.Property(x => x.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired(true);

            builder.Property(x => x.ManufacturingDate)
                .HasColumnName("manufacturing_date")
                .IsRequired(true);

            builder.Property(x => x.SaleItemId)
                .HasColumnName("sale_item_id")
                .HasDefaultValue(null)
                .IsRequired(false);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
            
            builder.HasOne(x => x.Supplier)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Branch)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.SaleItem)
                .WithMany(y => y.ProductsInInventory)
                .HasForeignKey(x => x.SaleItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }

        private protected override void SetData(EntityTypeBuilder<ProductInInventory> builder)
        {
            const int count = 120;
            var defaultProductsInInventory = new ProductInInventory[count];

            for (int i = 0; i < count; i++)
            {
                defaultProductsInInventory[i] = new()
                {
                    Id = (uint)(i + 1),
                    ProductId = (uint)((i / 20) + 1),
                    SupplierId = (uint)((i / 20) + 1),
                    BranchId = 1,
                    SaleItemId = null,
                    CreatedAt = DEFAULT_CREATED_AT
                };
            }

            const int totalSaleItemProductInInventory = 24;
            var saleItemProductsInInventory = new ProductInInventory[totalSaleItemProductInInventory];

            for (int i = 0; i < totalSaleItemProductInInventory; i++)
            {
                saleItemProductsInInventory[i] = new()
                {
                    Id = (uint)(count + i + 1),
                    ProductId = (uint)Math.Ceiling((i + 1) / 4m),
                    SupplierId = (uint)Math.Ceiling((i + 1) / 4m),
                    BranchId = 1,
                    SaleItemId = (uint)Math.Ceiling((i + 1) / 2m),
                    CreatedAt = DEFAULT_CREATED_AT
                };
            }

            builder.HasData(defaultProductsInInventory.Concat(saleItemProductsInInventory));
        }
    }
}
