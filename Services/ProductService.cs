using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;
using System.Text;

namespace Projeto_Aplicado_II_API.Services
{
    public class ProductService(MainDbContext db,
        IProductRepository productRepository,
        ICompanyRepository companyRepository,
        IProductCategoryRepository productCategoryRepository,
        AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IProductCategoryRepository _productCategoryRepository = productCategoryRepository;
        private readonly AuthService _authService = authService;

        public async Task<uint> CreateAsync(CreateProductDto dto)
        {
            var product = Product.CreateFromDto(dto);

            var branch = await _authService.GetLoggedBranchAsync();

            ProductCategory? category;

            if (dto.ProductCategoryId == 0)
            {
                category = new()
                {
                    CompanyId = branch.CompanyId,
                    Description = dto.OtherProductCategory ?? "Nova categoria"
                };
            }
            else
            {
                category = await _productCategoryRepository.GetByIdThrowsIfNullAsync(dto.ProductCategoryId);
            }

            product.CompanyId = branch.CompanyId;
            product.ProductCategory = category;

            await _db.RunInTransactionAsync(async () =>
            {
                if (dto.ProductCategoryId == 0) await _productCategoryRepository.AddAsync(category);
                await _productRepository.AddAsync(product);
                await _db.SaveChangesAsync();

                GenerateEan13BarCode(product);
                _productRepository.Update(product);
            });

            return product.Id;
        }

        private static void GenerateEan13BarCode(Product product)
        {
            var brazilEanPrefix = "789";

            var strBuilder = new StringBuilder(brazilEanPrefix);

            var companyIdentifier = product.CompanyId.ToString().PadLeft(6, '0');
            var productIdentifier = product.Id.ToString().PadLeft(3, '0');

            strBuilder.Append(companyIdentifier);
            strBuilder.Append(productIdentifier);

            var ean12 = strBuilder.ToString();

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < 12; i++)
            {
                int digit = ean12[i] - '0';
                if ((i + 1) % 2 == 0) evenSum += digit;
                else oddSum += digit;
            }

            int total = oddSum + (evenSum * 3);
            int nearestTen = (int)Math.Ceiling(total / 10f) * 10;
            int checkDigit = nearestTen - total;

            if (checkDigit == 10) checkDigit = 0;

            product.Ean13BarCode = ean12 + checkDigit;
        }


        public async Task<ProductDto> GetByIdAsync(uint id)
        {
            var product = await _productRepository.GetByIdThrowsIfNullAsync(id);

            return ProductDto.FromProduct(product);
        }

        public async Task<uint> UpdateAsync(uint id, CreateProductDto dto)
        {
            var branch = await _authService.GetLoggedBranchAsync();
            var product = await _productRepository.GetByIdThrowsIfNullAsync(id);

            product.Name = dto.Name;

            var category = new ProductCategory();

            if (dto.ProductCategoryId == 0)
            {
                category = new()
                {
                    CompanyId = branch.CompanyId,
                    Description = dto.OtherProductCategory ?? "Nova categoria"
                };
            }
            else
            {
                category = await _productCategoryRepository.GetByIdThrowsIfNullAsync(dto.ProductCategoryId);
            }

            product.ProductCategory = category;
            product.UnitarySellingPrice = dto.UnitarySellingPrice;
            product.UnityOfMeasureId = dto.UnityOfMeasureId;
            product.MinimalInventoryQuantity = dto.MinimalInventoryQuantity;

            await _db.RunInTransactionAsync(async () =>
            {
                if (dto.ProductCategoryId == 0) await _productCategoryRepository.AddAsync(category);
                _productRepository.Update(product);
            });

            return product.Id;
        }

        public async Task<List<CompanyProductDto>> ListCompanyProductsAsync(uint companyId)
        {
            await _companyRepository.ThrowIfNotExists(c => c.Id == companyId);

            return await _productRepository.ListCompanyProducts(companyId);
        }

        public async Task<bool> ToggleProductAsync(uint productId)
        {
            var product = await _productRepository.GetByIdThrowsIfNullAsync(productId);

            product.IsActive = !product.IsActive;

            await _db.RunInTransactionAsync(() =>
            {
                _productRepository.Update(product);
            });

            return product.IsActive;
        }
    }
}
