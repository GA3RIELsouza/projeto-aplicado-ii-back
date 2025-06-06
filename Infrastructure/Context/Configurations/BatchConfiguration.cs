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

        private protected override void SetData(EntityTypeBuilder<Batch> builder)
        {
            var defaultBatches = new Batch[]
            {
                new()
                {
                    Id = 1,
                    ProductId = 1,
                    BatchDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT),
                    ExpirationDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT)
                },
                new()
                {
                    Id = 2,
                    ProductId = 2,
                    BatchDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT),
                    ExpirationDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT)
                },
                new()
                {
                    Id = 3,
                    ProductId = 3,
                    BatchDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT),
                    ExpirationDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT)
                },
                new()
                {
                    Id = 4,
                    ProductId = 4,
                    BatchDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT),
                    ExpirationDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT)
                },
                new()
                {
                    Id = 5,
                    ProductId = 5,
                    BatchDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT),
                    ExpirationDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT)
                },
                new()
                {
                    Id = 6,
                    ProductId = 6,
                    BatchDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT),
                    ExpirationDate = DateOnly.FromDateTime(DEFAULT_CREATED_AT)
                }
            };

            builder.HasData(defaultBatches);
        }
    }
}
