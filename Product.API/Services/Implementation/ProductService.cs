using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;

namespace Product.API.Services.Implementation
{
    public class ProductService : IProductService
    {   
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto)
        {
            var product = ModelConverter.DtoToModel(productDto);
            if (product.Id > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }
            await _dbContext.SaveChangesAsync();
            return ModelConverter.ModeltoDto(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
           var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            var products = await _dbContext.Products.Select(product => ModelConverter.ModeltoDto(product)).ToListAsync();
            return products;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            return await _dbContext.Products.Select(product => ModelConverter.ModeltoDto(product)).FirstOrDefaultAsync();
        }
    }
}
