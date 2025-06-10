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

            builder.Property(x => x.SaleDateTime)
                .HasColumnName("sale_date_time")
                .IsRequired(true);
            
            builder.HasOne(x => x.Branch)
                .WithMany(y => y.Sales)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<Sale> builder)
        {
            const int count = 12;
            var defaultSales = new Sale[count];

            for (int i = 0; i < count; i++)
            {
                defaultSales[i] = new()
                {
                    Id = (uint)(i + 1),
                    BranchId = 1,
                    SaleDateTime = DEFAULT_CREATED_AT
                };
            }

            builder.HasData(defaultSales);
        }
    }
}
