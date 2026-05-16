using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }

        [Required]
        public string category_name { get; set; }

        public ICollection<Item>? item { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

        public byte[]? dbImage { get; set; }
        [NotMapped]
        public string? imageSrc {
            get 
            {
                if (dbImage != null)
                {
                    string base64String = Convert.ToBase64String(dbImage, 0, dbImage.Length);
                    return "data:image/jpg;base64," + base64String;

                }
                else 
                {
                return string.Empty;
                }
            
            }
                
                
                }
    }
}
