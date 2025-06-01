using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class BatchConfiguration : EntityBaseConfiguration<Batch>
    {
        public override void Configure(EntityTypeBuilder<Batch> builder)
        {
            base.Configure(builder);

            builder.ToTable("batch");

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired(true);

            builder.Property(x => x.BatchDate)
                .HasColumnName("batch_date")
                .IsRequired(true);

            builder.Property(x => x.ExpirationDate)
                .HasColumnName("expiration_date")
                .IsRequired(true);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.Batches)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
