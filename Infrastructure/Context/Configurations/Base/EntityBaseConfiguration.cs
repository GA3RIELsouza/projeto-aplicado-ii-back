using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.ValueObjects;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base
{
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public static readonly DateTime DEFAULT_CREATED_AT = new(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static readonly Action<OwnedNavigationBuilder<TEntity, Address>> DEFAULT_ADDRESS_BUILDER = builder =>
        {
            builder.Property(a => a.Street)
                .HasColumnName("street")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(a => a.Number)
                .HasColumnName("number")
                .HasMaxLength(10)
                .IsRequired(true);

            builder.Property(a => a.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(a => a.City)
                .HasColumnName("city")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(a => a.State)
                .HasColumnName("state")
                .HasMaxLength(2)
                .IsRequired(true);

            builder.Property(a => a.Country)
                .HasColumnName("country")
                .HasMaxLength(50)
                .IsRequired(true);
        };

        public static readonly Action<OwnedNavigationBuilder<TEntity, Address>> DEFAULT_NULLABLE_ADDRESS_BUILDER = builder =>
        {
            builder.Property(a => a.Street)
                .HasColumnName("street")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(a => a.Number)
                .HasColumnName("number")
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(a => a.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(a => a.City)
                .HasColumnName("city")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(a => a.State)
                .HasColumnName("state")
                .HasMaxLength(2)
                .IsRequired(false);

            builder.Property(a => a.Country)
                .HasColumnName("country")
                .HasMaxLength(50)
                .IsRequired(false);
        };

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityColumn()
                .IsRequired(true);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired(true);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false);

            SetData(builder);
        }

        private protected virtual void SetData(EntityTypeBuilder<TEntity> builder) { }
    }
}
