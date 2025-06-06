using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Enums;
using Projeto_Aplicado_II_API.Infrastructure.Context.Configurations.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Context.Configurations
{
    public class ProductConfiguration : CompanyOwnedEntityBaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("product");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(512)
                .IsRequired(true);

            builder.Property(x => x.ImageUrl)
                .HasColumnName("image_url")
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(x => x.ProductCategoryId)
                .HasColumnName("product_category_id")
                .IsRequired(true);

            builder.Property(x => x.UnitarySellingPrice)
                .HasColumnName("unitary_selling_price")
                .HasPrecision(8, 2)
                .IsRequired(true);

            builder.Property(x => x.UnityOfMeasureId)
                .HasColumnName("unity_of_measure_id")
                .IsRequired(true);

            builder.Property(x => x.MinimalStockQuantity)
                .HasColumnName("minimal_stock_quantity")
                .HasDefaultValue(10)
                .IsRequired(true);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.UnityOfMeasure)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.UnityOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne(x => x.Company)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }

        private protected override void SetData(EntityTypeBuilder<Product> builder)
        {
            var defaultProducts = new Product[]
            {
                new()
                {
                    Id = 1,
                    CompanyId = 1,
                    Name = "Banana Prata",
                    Description = "Banana Prata",
                    ImageUrl = "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/152c5248ec73694bf1cf8be92c1d8e4720240227033525/450/banana-prata-kg_2019.jpg",
                    ProductCategoryId = 1,
                    UnitarySellingPrice = 6.89m,
                    MinimalStockQuantity = 10,
                    UnityOfMeasureId = (uint)EUnityOfMeasure.KILOGRAM
                },
                new()
                {
                    Id = 2,
                    CompanyId = 1,
                    Name = "Batata Inglesa Lavada",
                    Description = "Batata Inglesa Lavada",
                    ImageUrl = "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/fb1a588af874d79db3c0c6ae8512a83e20240226225359/450/batata-inglesa-lavada-kg_7172.jpg",
                    ProductCategoryId = 1,
                    UnitarySellingPrice = 5.98m,
                    MinimalStockQuantity = 10,
                    UnityOfMeasureId = (uint)EUnityOfMeasure.KILOGRAM
                },
                new()
                {
                    Id = 3,
                    CompanyId = 1,
                    Name = "Suco Integral Laranja Prat's Garrafa 1,5l",
                    Description = "Suco Integral Laranja Prat's Garrafa 1,5l",
                    ImageUrl = "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/0b2f3c4a5e6f7b8c9d0e1f2a3b4c5d6e20240226225359/450/suco-integral-laranja-prats-garrafa-15l_7172.jpg",
                    ProductCategoryId = 2,
                    UnitarySellingPrice = 23.99m,
                    MinimalStockQuantity = 10,
                    UnityOfMeasureId = (uint)EUnityOfMeasure.UNITY
                },
                new()
                {
                    Id = 4,
                    CompanyId = 1,
                    Name = "Vinho Chileno Cabernet Sauvignon Montes Reserva Garrafa 750ml",
                    Description = "Vinho Chileno Cabernet Sauvignon Montes Reserva Garrafa 750ml",
                    ImageUrl = "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/e7e4a170a063c2102b4470ce991b714a20250409101224/450/vinho-chileno-cabernet-sauvignon-montes-reserva-garrafa-750ml_8040.jpg",
                    ProductCategoryId = 2,
                    UnitarySellingPrice = 99.90m,
                    MinimalStockQuantity = 10,
                    UnityOfMeasureId = (uint)EUnityOfMeasure.UNITY
                },
                new()
                {
                    Id = 5,
                    CompanyId = 1,
                    Name = "Costela Bovina Precoce Verdi",
                    Description = "Costela Bovina Precoce Verdi",
                    ImageUrl = "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/620ec78bf82c5deb224d95c0544a8f1e20250514171231/450/costela-bovina-precoce-verdi-kg_2380.jpg",
                    ProductCategoryId = 3,
                    UnitarySellingPrice = 36.98m,
                    MinimalStockQuantity = 10,
                    UnityOfMeasureId = (uint)EUnityOfMeasure.KILOGRAM
                },
                new()
                {
                    Id = 6,
                    CompanyId = 1,
                    Name = "Filé Simples Bovino Precoce Verdi",
                    Description = "Filé Simples Bovino Precoce Verdi",
                    ImageUrl = "https://d8vlg9z1oftyc.cloudfront.net/minhacooper/image/product/8e15f72024db65d4faac6f3f07b2777920250509081238/450/file-simples-bovino-precoce-verdi-kg_4970.jpg",
                    ProductCategoryId = 3,
                    UnitarySellingPrice = 47.90m,
                    MinimalStockQuantity = 10,
                    UnityOfMeasureId = (uint)EUnityOfMeasure.KILOGRAM
                }
            };

            builder.HasData(defaultProducts);
        }
    }
}
