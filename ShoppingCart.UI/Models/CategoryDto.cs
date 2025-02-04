using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.UI.Models
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
