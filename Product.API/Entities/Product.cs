using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }  
        [Required]
        public string ImageUrl { get; set; }
        [Required]  
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
