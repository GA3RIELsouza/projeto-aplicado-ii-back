using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class ProductCategoryConfiguration : CompanyOwnedEntityBaseConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_category");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.HasOne(x => x.Company)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
