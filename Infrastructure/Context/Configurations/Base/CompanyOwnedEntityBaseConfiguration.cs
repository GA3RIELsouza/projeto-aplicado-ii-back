using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base
{
    public abstract class CompanyOwnedEntityBaseConfiguration<TEntity> : EntityBaseConfiguration<TEntity> where TEntity : CompanyOwnedEntityBase
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired(true);

            //builder.HasOne(x => x.Company)
            //    .WithMany()
            //    .HasForeignKey(x => x.CompanyId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(true);
        }
    }
}
