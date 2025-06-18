using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class UnityOfMeasureConfiguration : EntityBaseConfiguration<UnityOfMeasure>
    {
        public override void Configure(EntityTypeBuilder<UnityOfMeasure> builder)
        {
            base.Configure(builder);

            builder.ToTable("unity_of_measure");

            builder.Property(x => x.CompanyId)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(x => x.Symbol)
                .HasMaxLength(8)
                .IsRequired(true);

            builder.HasOne(x => x.Company)
                .WithMany(y => y.UnitiesOfMeasure)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasIndex(x => x.Description)
                .IsUnique(true);
        }

        private protected override void SetData(EntityTypeBuilder<UnityOfMeasure> builder)
        {
            var unitiesOfMeasure = new UnityOfMeasure[]
            {
                new() { Id = 1, CompanyId = null, Description = "Unidade", Symbol = "UN", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 2, CompanyId = null, Description = "Quilograma", Symbol = "kg", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 3, CompanyId = null, Description = "Grama", Symbol = "g", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 4, CompanyId = null, Description = "Miligrama", Symbol = "mg", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 5, CompanyId = null, Description = "Litro", Symbol = "L", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 6, CompanyId = null, Description = "Mililitro", Symbol = "mL", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 7, CompanyId = null, Description = "Metro", Symbol = "m", CreatedAt = DEFAULT_CREATED_AT },
                new() { Id = 8, CompanyId = null, Description = "Milímetro", Symbol = "ml", CreatedAt = DEFAULT_CREATED_AT }
            };

            builder.HasData(unitiesOfMeasure);
        }
    }
}
