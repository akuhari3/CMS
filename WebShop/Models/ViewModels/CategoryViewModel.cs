using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required!")]
        [StringLength(50, MinimumLength = 2)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category description is required!")]
        [StringLength(200, MinimumLength = 2)]
        public string CategoryDescription { get; set; }
        public IFormFile CategoryImage { get; set; }
    }
}
