using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class BranchConfiguration : CompanyOwnedEntityBaseConfiguration<Branch>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            base.Configure(builder);

            builder.ToTable("branch");

            builder.OwnsOne(x => x.Address, DEFAULT_ADDRESS_BUILDER);

            builder.Property(x => x.BranchSizeId)
                .HasColumnName("branch_size_id")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired(true);

            builder.HasOne(x => x.BranchSize)
                .WithMany(y => y.Branches)
                .HasForeignKey(x => x.BranchSizeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Company)
                .WithMany(y => y.Branches)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
