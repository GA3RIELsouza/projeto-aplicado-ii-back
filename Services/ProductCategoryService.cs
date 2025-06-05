using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class ProductCategoryService(MainDbContext db, IProductCategoryRepository productCategoryRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;

        public async Task<uint> CreateAsync(CreateProductCategoryDto dto)
        {
            var productCategory = ProductCategory.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _productCategoryRepository.AddAsync(productCategory);
            });

            return productCategory.Id;
        }

        public async Task<ProductCategoryDto> GetByIdAsync(uint id)
        {
            var productCategory = await _productCategoryRepository.GetByIdIncludesThrowsIfNullAsync(id, null, pc => pc.Company);

            return ProductCategoryDto.FromProductCategory(productCategory);
        }
    }
}
