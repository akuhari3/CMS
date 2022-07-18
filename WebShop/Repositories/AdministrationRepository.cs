using Microsoft.AspNetCore.Identity;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class AdministrationRepository : IAdministrationRepository
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        #endregion


        #region Constructors
        public AdministrationRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }
        #endregion

        #region Administration Repository Implementation

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _userManager.Users;
        }

        

        public async Task<IdentityResult> AddUser(UserViewModel user)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Timezone = user.Timezone,
                Active = user.Active,

            };

            if (user.Avatar != null)
            {
                using (var stream = new MemoryStream())
                {
                    user.Avatar.CopyTo(stream);
                    var file = stream.ToArray();

                    appUser.Avatar = file;
                }
            }

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, user.Password);

            return identityResult;
        }

        public async Task<ApplicationUser> GetUserAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public string PasswordHasher(ApplicationUser user, string password)
        {
            var hash = _passwordHasher.HashPassword(user, password);
            return hash;
        }

        public async Task<IdentityResult> UpdateUser(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUser(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<List<UserRolesViewModel>> GetUsersAndRolesAsync(IEnumerable<ApplicationUser> users)
        {
            var usersWithRoles = new List<UserRolesViewModel>();

            foreach (ApplicationUser user in users)
            {
                var userWithRoles = new UserRolesViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Roles = new List<string>(await _userManager.GetRolesAsync(user))
                };

                usersWithRoles.Add(userWithRoles);
            }

            return usersWithRoles;
        }

        public async Task<List<AddRemoveUserRolesViewModel>> AddUserRoleAsync(ApplicationUser user)
        {
            var model = new List<AddRemoveUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var addRemoveUserRole = new AddRemoveUserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addRemoveUserRole.Selected = true;
                }
                else
                {
                    addRemoveUserRole.Selected = false;
                }
                model.Add(addRemoveUserRole);
            }

            return model;
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> DeleteUserFromRolesAsync(ApplicationUser user, IList<string> roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<IdentityResult> AddUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles, List<AddRemoveUserRolesViewModel> model)
        {
            var result = await _userManager.AddToRolesAsync
                (user, model.Where(role => role.Selected == true)
                .Select(role => role.RoleName));
            return result;
        }

        public List<IdentityRole> GetUserRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public void AddUserRole(string roleName)
        {
            _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
        }


        #endregion

        #region Dropdown Users


        #endregion


    }
}
