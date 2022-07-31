using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(200, MinimumLength = 2)]
        [Display(Name = "Title")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product description is required!")]
        [StringLength(200, MinimumLength = 2)]
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Product quantity is required!")]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Product price is required!")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Product Image")]
        public IFormFile ProductImage { get; set; }
    }
}