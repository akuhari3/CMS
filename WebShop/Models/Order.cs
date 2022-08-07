using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class Order
    {
        [DisplayName("Order ID")]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Total price is required!")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string BillingFirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string BillingLastName { get; set; }
        [Required(ErrorMessage = "Email Address is required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid!")]
        [DisplayName("Email")]
        public string BillingEmail { get; set; }
        [Required(ErrorMessage = "Phone number is required!")]
        [DisplayName("Phone")]
        public string BillingPhone { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        [StringLength(200)]
        [DisplayName("Address")]
        public string BillingAddress { get; set; }
        [Required(ErrorMessage = "City is required!")]
        [StringLength(100)]
        [DisplayName("City")]
        public string BillingCity { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Country is required!")]
        [DisplayName("Country")]
        public string BillingCountry { get; set; }
        [Required(ErrorMessage = "Postal code is required!")]
        [StringLength(20)]
        [DisplayName("Zip")]
        public string BillingZip { get; set; }
        [DisplayName("Order State")]
        public OrderState OrderState { get; set; }

        [ForeignKey("OrderId")]
        public List<OrderItem> OrderItems { get; set; }
        [DisplayName("User")]
        public string UserId { get; set; }

    }
}
