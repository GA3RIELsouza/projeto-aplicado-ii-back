using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base
{
    public abstract class BranchOwnedEntityBaseConfiguration<TEntity> : EntityBaseConfiguration<TEntity> where TEntity : BranchOwnedEntityBase
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BranchId)
                .HasColumnName("branch_id")
                .IsRequired(true);

            //builder.HasOne(x => x.Branch)
            //    .WithMany()
            //    .HasForeignKey(x => x.BranchId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(true);
        }
    }
}
