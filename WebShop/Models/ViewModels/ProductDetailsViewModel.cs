using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.ViewModels
{
    public class ProductDetailsViewModel
    {

        [Display(Name = "Title")]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Product Image")]
        public IFormFile ProductImage { get; set; }
    }
}