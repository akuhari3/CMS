using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Timezone is required!")]
        public Timezone Timezone { get; set; }
        public bool Active { get; set; }
        public byte[] Avatar { get; set; }
        [ForeignKey("UserId")]
        public List<Order> Orders { get; set; }
    }
}
