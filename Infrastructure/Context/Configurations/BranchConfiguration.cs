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

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Street)
                .HasColumnName("street")
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.Number)
                .HasColumnName("number")
                .HasMaxLength(16)
                .IsRequired(true);

            builder.Property(x => x.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.City)
                .HasColumnName("city")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.State)
                .HasColumnName("state")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Country)
                .HasColumnName("country")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.BranchSizeId)
                .HasColumnName("branch_size_id")
                .IsRequired(true);

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

        private protected override void SetData(EntityTypeBuilder<Branch> builder)
        {
            var defaultBranches = new Branch[]
            {
                new()
                {
                    Id = 1,
                    CompanyId = 1,
                    Name = "Filial Padrão 1",
                    Street = "Rua Exemplo 1",
                    Number = "123",
                    Neighborhood = "Bairro Exemplo",
                    City = "Cidade Exemplo",
                    State = "EX",
                    Country = "Brasil",
                    BranchSizeId = 1,
                    IsActive = true
                },
                new()
                {
                    Id = 2,
                    CompanyId = 1,
                    Name = "Filial Padrão 2",
                    Street = "Rua Exemplo 2",
                    Number = "124",
                    Neighborhood = "Bairro Exemplo",
                    City = "Cidade Exemplo",
                    State = "EX",
                    Country = "Brasil",
                    BranchSizeId = 2,
                    IsActive = true
                },
                new()
                {
                    Id = 3,
                    CompanyId = 1,
                    Name = "Filial Padrão 3",
                    Street = "Rua Exemplo 3",
                    Number = "125",
                    Neighborhood = "Bairro Exemplo",
                    City = "Cidade Exemplo",
                    State = "EX",
                    Country = "Brasil",
                    BranchSizeId = 3,
                    IsActive = true
                }
            };

            builder.HasData(defaultBranches);
        }
    }
}
