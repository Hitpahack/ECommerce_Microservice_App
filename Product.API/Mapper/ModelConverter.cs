using Product.API.DTO;
using Product.API.Entities;

namespace Product.API.Mapper
{
    public class ModelConverter
    {
        public static Entities.Product DtoToModel(ProductDto model)
        {
            return new Entities.Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
            };
        }
        public static ProductDto ModeltoDto(Entities.Product model)
        {
            return new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,    
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
            };
        }
        public static Entities.Category DtoToModel(CategoryDto model)
        {
            return new Entities.Category
            {
                Id = model.Id,
                CategoryName = model.CategoryName
            };
        }
        public static CategoryDto ModeltoDto(Entities.Category model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                CategoryName=model.CategoryName,
            };
        }

       
    }
}
