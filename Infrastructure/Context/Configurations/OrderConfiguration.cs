using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class OrderConfiguration : BranchOwnedEntityBaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("order");

            builder.Property(x => x.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired(true);

            builder.Property(x => x.OrderDateTime)
                .HasColumnName("order_date_time")
                .IsRequired(true);

            builder.Property(x => x.DeliveryDateTime)
                .HasColumnName("delivery_date_time")
                .IsRequired(false);

            builder.Property(x => x.OrderStatusId)
                .HasColumnName("order_status_id")
                .IsRequired(true);

            builder.HasOne(x => x.Supplier)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.OrderStatus)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Branch)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<Order> builder)
        {
            var defaultOrders = new Order[]
            {
                new()
                {
                    Id = 1,
                    BranchId = 1,
                    SupplierId = 1,
                    OrderDateTime = DEFAULT_CREATED_AT,
                    DeliveryDateTime = DEFAULT_CREATED_AT,
                    OrderStatusId = 3
                },
                new()
                {
                    Id = 2,
                    BranchId = 1,
                    SupplierId = 2,
                    OrderDateTime = DEFAULT_CREATED_AT,
                    DeliveryDateTime = DEFAULT_CREATED_AT,
                    OrderStatusId = 3
                },
                new()
                {
                    Id = 3,
                    BranchId = 1,
                    SupplierId = 3,
                    OrderDateTime = DEFAULT_CREATED_AT,
                    DeliveryDateTime = DEFAULT_CREATED_AT,
                    OrderStatusId = 3
                },
                new()
                {
                    Id = 4,
                    BranchId = 1,
                    SupplierId = 4,
                    OrderDateTime = DEFAULT_CREATED_AT,
                    DeliveryDateTime = DEFAULT_CREATED_AT,
                    OrderStatusId = 3
                },
                new()
                {
                    Id = 5,
                    BranchId = 1,
                    SupplierId = 5,
                    OrderDateTime = DEFAULT_CREATED_AT,
                    DeliveryDateTime = DEFAULT_CREATED_AT,
                    OrderStatusId = 3
                },
                new()
                {
                    Id = 6,
                    BranchId = 1,
                    SupplierId = 6,
                    OrderDateTime = DEFAULT_CREATED_AT,
                    DeliveryDateTime = DEFAULT_CREATED_AT,
                    OrderStatusId = 3
                }
            };

            builder.HasData(defaultOrders);
        }
    }
}
