using System.Collections.Generic;

namespace WebShop.Models
{
    public class UserRolesViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
