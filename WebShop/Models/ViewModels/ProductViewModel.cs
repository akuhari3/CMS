using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(200, MinimumLength = 2)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product description is required!")]
        [StringLength(200, MinimumLength = 2)]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Product quantity is required!")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Product price is required!")]
        public decimal Price { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
