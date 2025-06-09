using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base
{
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public static readonly DateTime DEFAULT_CREATED_AT = new(2025, 09, 06, 12, 30, 0, DateTimeKind.Utc);

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
