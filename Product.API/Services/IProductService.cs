using Product.API.DTO;

namespace Product.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct();

        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateUpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(int id);
    }
}
