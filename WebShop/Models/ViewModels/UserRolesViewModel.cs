using System.Collections.Generic;

namespace WebShop.Models
{
    public class UserRolesViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Timezone Timezone { get; set; }
        public bool Active { get; set; }
        public List<string> Roles { get; set; }
    }
}