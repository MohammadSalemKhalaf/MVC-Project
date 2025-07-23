using System.ComponentModel.DataAnnotations;

namespace E_commerce_mvc.Models
{
    public class Category
    {
         public int  Id { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
