using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class ProductService(MainDbContext db, IProductRepository productRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<uint> CreateAsync(CreateProductDto dto)
        {
            var product = Product.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _productRepository.AddAsync(product);
            });

            return product.Id;
        }

        public async Task<ProductDto> GetByIdAsync(uint id)
        {
            var product = await _productRepository.GetByIdIncludesThrowsIfNullAsync(id, null, p => p.ProductCategory, p => p.UnityOfMeasure);

            return ProductDto.FromProduct(product);
        }
    }
}
