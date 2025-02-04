using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Entities;
using Product.API.Mapper;

namespace Product.API.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext _dbContext;
        public async Task<CategoryDto> CreateUpdateCategoryAsync(CategoryDto categoryDto)
        {
            var category = ModelConverter.DtoToModel(categoryDto);
            if (category.Id > 0)
            {   
                _dbContext.Categories.Update(category);
            }
            else
            {
                _dbContext.Categories.Add(category);
            }
            await _dbContext.SaveChangesAsync();
            var dtoCategory = ModelConverter.ModeltoDto(category);
            return dtoCategory;

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return false;
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var category = await _dbContext.Categories.Select(category => ModelConverter.ModeltoDto(category)).ToListAsync();
            return category;
        }

        public async Task<CategoryDto> GetCategoryId(int id)
        {
            return await _dbContext.Categories.Select(category => ModelConverter.ModeltoDto(category)).FirstOrDefaultAsync();
        }
    }
}
