using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(254)
                .IsRequired(true);

            builder.Property(x => x.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(32)
                .IsFixedLength(true)
                .IsRequired(true);

            builder.Property(x => x.PasswordSaltHash)
                .HasColumnName("password_salt_hash")
                .HasMaxLength(16)
                .IsFixedLength(true)
                .IsRequired(true);

            builder.Property(x => x.IsAdmin)
                .HasColumnName("is_admin")
                .ValueGeneratedOnAdd()
                .HasDefaultValue(false)
                .IsRequired(true);

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired(true);

            builder.HasIndex(x => x.Email)
                .IsUnique(true);
        }

        private protected override void SetData(EntityTypeBuilder<User> builder)
        {
            var admin = new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@admin.com",
                PasswordHash = // sesisenai
                [
                    0x6A, 0x51, 0x2C, 0x50, 0x4B, 0x9D, 0xDC, 0xCF,
                    0xB9, 0xFA, 0xCA, 0x0D, 0x0A, 0x3B, 0x75, 0x8A,
                    0xAC, 0xE6, 0x4A, 0xDF, 0xBD, 0x01, 0x98, 0x42,
                    0x92, 0xB4, 0xAE, 0x09, 0x68, 0x09, 0x03, 0x7E
                ],
                PasswordSaltHash =
                [
                    0x63, 0xD4, 0x5D, 0xC5, 0x5D, 0x7F, 0x56, 0x97,
                    0x32, 0x5E, 0x50, 0x6C, 0x40, 0xE8, 0x16, 0x98
                ],
                IsAdmin = true,
                CreatedAt = DEFAULT_CREATED_AT,
                UpdatedAt = null
            };

            builder.HasData(admin);
        }
    }
}
