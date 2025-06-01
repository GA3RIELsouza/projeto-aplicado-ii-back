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
    }
}
