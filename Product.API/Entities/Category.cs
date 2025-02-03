using System.ComponentModel.DataAnnotations;

namespace Product.API.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}