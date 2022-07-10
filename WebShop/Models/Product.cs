using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(200, MinimumLength = 2)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product quantity is required!")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Product price is required!")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }
        public byte[] ProductImage { get; set; }
        [ForeignKey("ProductId")]
        public List<OrderItem> OrderItems { get; set; }
        [ForeignKey("ProductId")]
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
