using System.ComponentModel.DataAnnotations;

namespace Product.API.DTO
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
