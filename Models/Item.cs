using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [DisplayName("The Name")]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("The Price")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("The Category")]
        [ForeignKey("category")]
        public int category_id { get; set; }

        public Category? category { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

        public string? imgPath { get; set; }
    }
}
