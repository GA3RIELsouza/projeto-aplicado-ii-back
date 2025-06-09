using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class UserBranchConfiguration : BranchOwnedEntityBaseConfiguration<UserBranch>
    {
        public override void Configure(EntityTypeBuilder<UserBranch> builder)
        {
            base.Configure(builder);

            builder.ToTable("user_branch");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(y => y.UserBranches)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(x => x.Branch)
                .WithMany(y => y.UserBranches)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasIndex(x => new { x.UserId, x.BranchId })
                .IsUnique(true);
        }

        private protected override void SetData(EntityTypeBuilder<UserBranch> builder)
        {
            var defaultUserBranches = new UserBranch[]
            {
                new()
                {
                    Id = 1,
                    UserId = 1,
                    BranchId = 1
                },
                new()
                {
                    Id = 2,
                    UserId = 1,
                    BranchId = 2
                },
                new()
                {
                    Id = 3,
                    UserId = 1,
                    BranchId = 3
                }
            };

            builder.HasData(defaultUserBranches);
        }
    }
}
