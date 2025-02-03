using Product.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Product.API.DTO
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string CategoryId { get; set; }
    }
    
}
