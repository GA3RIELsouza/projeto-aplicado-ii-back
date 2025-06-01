using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class ProductConfiguration : CompanyOwnedEntityBaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("product");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(512)
                .IsRequired(true);

            builder.Property(x => x.ImageUrl)
                .HasColumnName("image_url")
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(x => x.ProductCategoryId)
                .HasColumnName("product_category_id")
                .IsRequired(true);

            builder.Property(x => x.UnitarySellingPrice)
                .HasColumnName("unitary_selling_price")
                .HasPrecision(8, 2)
                .IsRequired(true);

            builder.Property(x => x.UnityOfMeasureId)
                .HasColumnName("unity_of_measure_id")
                .IsRequired(true);

            builder.HasOne(x => x.ProductCategory)
                .WithMany()
                .HasForeignKey(x => x.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.UnityOfMeasure)
                .WithMany()
                .HasForeignKey(x => x.UnityOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Company)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasMany(x => x.SaleItems)
                .WithOne(y => y.Product)
                .HasForeignKey(y => y.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasMany(x => x.Batches)
                .WithOne(y => y.Product)
                .HasForeignKey(y => y.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasMany(x => x.ProductsInInventory)
                .WithOne(y => y.Product)
                .HasForeignKey(y => y.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
