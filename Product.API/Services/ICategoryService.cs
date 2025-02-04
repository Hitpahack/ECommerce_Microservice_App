using Product.API.DTO;

namespace Product.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategory();
        Task<CategoryDto> GetCategoryId(int id);
        Task<CategoryDto> CreateUpdateCategoryAsync(CategoryDto product);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
