using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password confirmation is required!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatedPassword { get; set; }
        public bool Active { get; set; }
        public Timezone Timezone { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
