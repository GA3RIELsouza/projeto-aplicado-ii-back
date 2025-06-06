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

            builder.Property(x => x.Description)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Symbol)
                .HasMaxLength(8)
                .IsRequired();
        }

        private protected override void SetData(EntityTypeBuilder<UnityOfMeasure> builder)
        {
            var unitiesOfMeasure = new UnityOfMeasure[]
            {
                new() { Id = 1, Description = "Unidade", Symbol = "UN" },
                new() { Id = 2, Description = "Quilograma", Symbol = "kg" },
                new() { Id = 3, Description = "Grama", Symbol = "g" },
                new() { Id = 4, Description = "Miligrama", Symbol = "mg" },
                new() { Id = 5, Description = "Litro", Symbol = "L" },
                new() { Id = 6, Description = "Mililitro", Symbol = "mL" },
                new() { Id = 7, Description = "Quilômetro", Symbol = "km" },
                new() { Id = 8, Description = "Metro", Symbol = "m" },
                new() { Id = 9, Description = "Milímetro", Symbol = "ml" }
            };

            builder.HasData(unitiesOfMeasure);
        }
    }
}
