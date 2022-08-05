using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Models;

namespace WebShop.Interfaces
{
    public interface IAdministrationRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        Task<IdentityResult> AddUser(UserViewModel user);
        Task<ApplicationUser> GetUserAsync(string id);
        string PasswordHasher(ApplicationUser user, string password);
        Task<IdentityResult> UpdateUser(ApplicationUser user);
        Task<IdentityResult> DeleteUser(ApplicationUser user);
        Task<List<UserRolesViewModel>> GetUsersAndRolesAsync(IEnumerable<ApplicationUser> users);
        Task<List<AddRemoveUserRolesViewModel>> AddUserRoleAsync(ApplicationUser user);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IdentityResult> DeleteUserFromRolesAsync(ApplicationUser user, IList<string> roles);
        Task<IdentityResult> AddUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles, List<AddRemoveUserRolesViewModel> model);
        List<IdentityRole> GetUserRoles();
        void AddUserRole(string roleName);
        List<ApplicationUser> QueryStringFilterUsers(string s, string orderBy, int perPage);
        List<SelectListItem> TimezonesForDropDownList();
    }
}
