using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class OrderStatusConfiguration : EntityBaseConfiguration<OrderStatus>
    {
        public override void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            base.Configure(builder);

            builder.ToTable("order_status");

            builder.Property(x => x.Description)
                .HasMaxLength(128)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<OrderStatus> builder)
        {
            var defaultOrderStatuses = new OrderStatus[]
            {
                new()
                {
                    Id = 1,
                    Description = "Solicitado",
                    CreatedAt = DEFAULT_CREATED_AT,
                    UpdatedAt = null
                },
                new()
                {
                    Id = 2,
                    Description = "A caminho",
                    CreatedAt = DEFAULT_CREATED_AT,
                    UpdatedAt = null
                },
                new()
                {
                    Id = 3,
                    Description = "Concluído",
                    CreatedAt = DEFAULT_CREATED_AT,
                    UpdatedAt = null
                }
            };

            builder.HasData(defaultOrderStatuses);
        }
    }
}
