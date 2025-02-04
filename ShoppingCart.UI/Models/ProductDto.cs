
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.UI.Models
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
        public int CategoryId { get; set; }
    }
    
}
