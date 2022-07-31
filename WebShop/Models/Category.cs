using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required!")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Title")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category description is required!")]
        [StringLength(200, MinimumLength = 2)]
        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }
        [Display(Name = "Category Image")]
        public string CategoryImage { get; set; }
        [ForeignKey("CategoryId")]
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
