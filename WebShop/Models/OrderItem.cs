using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Quantity is required!")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Price is required!")]
        public decimal Price { get; set; }
        [NotMapped]
        public decimal Total { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
    }
}
