using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Timezone Timezone { get; set; }
        public bool Active { get; set; }
        public byte[] Avatar { get; set; }
        [ForeignKey("UserId")]
        public List<Order> Orders { get; set; }

        public string GetAvatar()
        {
            return Convert.ToBase64String(Avatar);
        }
    }
}
