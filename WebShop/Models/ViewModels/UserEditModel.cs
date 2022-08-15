using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class UserEditModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email address is required!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool Active { get; set; }
        public Timezone Timezone { get; set; }
        public string GetAvatarAsBase64String { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
