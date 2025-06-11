using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class BranchSizeConfiguration : EntityBaseConfiguration<BranchSize>
    {
        public override void Configure(EntityTypeBuilder<BranchSize> builder)
        {
            base.Configure(builder);

            builder.ToTable("branch_size");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(32)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<BranchSize> builder)
        {
            var branchSizes = new BranchSize[]
            {
                new()
                {
                    Id = 1,
                    Description = "Pequena",
                    CreatedAt = DEFAULT_CREATED_AT,
                    UpdatedAt = null
                },
                new()
                {
                    Id = 2,
                    Description = "Média",
                    CreatedAt = DEFAULT_CREATED_AT,
                    UpdatedAt = null
                },
                new()
                {
                    Id = 3,
                    Description = "Grande",
                    CreatedAt = DEFAULT_CREATED_AT,
                    UpdatedAt = null
                }
            };

            builder.HasData(branchSizes);
        }
    }
}
