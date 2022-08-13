using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin"), Area("Admin")]

    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        private IAdministrationRepository _administrationRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher, IAdministrationRepository administrationRepository, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _administrationRepository = administrationRepository;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string filter, string orderBy, int perPage)
        {
            var users = _userManager.Users.ToList();
            if (filter != null || perPage > 0)
            {
                orderBy = "asc";
                //perPage = 100;
                users = _administrationRepository.QueryStringFilterUsers(filter, orderBy, perPage);
            }
            var usersWithRoles = new List<UserRolesViewModel>();

            foreach (ApplicationUser user in users)
            {
                var userWithRoles = new UserRolesViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Active = user.Active,
                    Timezone = user.Timezone,
                    Roles = new List<string>(await _userManager.GetRolesAsync(user))
                };

                usersWithRoles.Add(userWithRoles);
            }

            return View(usersWithRoles);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = _userManager.Users.FirstOrDefault(a => a.Id == id);
            var roles = new List<string>(await _userManager.GetRolesAsync(user));
            ViewBag.UserList = roles;
            return View(user);
        }

        public IActionResult Create()
        {
            ViewBag.Timezones = _administrationRepository.TimezonesForDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
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

                if (identityResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Errors(identityResult);
                }
            }

            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            ViewBag.Timezones = _administrationRepository.TimezonesForDropDownList();
            var userEditModel = new UserEditModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Active = user.Active,
                Timezone = user.Timezone,
            };
            if (user != null)
            {
                return View(userEditModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserEditModel uem)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(uem.Id);
            if (appUser != null)
            {
                if (!string.IsNullOrEmpty(uem.Email))
                {
                    appUser.Email = uem.Email;
                }
                else
                {
                    ModelState.AddModelError("", "Email cannot be empty!");
                }

                if (!string.IsNullOrEmpty(uem.Password))
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, uem.Password);
                }
                else
                {
                    ModelState.AddModelError("", "Password cannot be empty!");
                }

                if (!string.IsNullOrEmpty(uem.FirstName))
                {
                    appUser.FirstName = uem.FirstName;
                }
                else
                {
                    ModelState.AddModelError("", "First name cannot be empty!");
                }

                if (!string.IsNullOrEmpty(uem.LastName))
                {
                    appUser.LastName = uem.LastName;
                }
                else
                {
                    ModelState.AddModelError("", "Last name cannot be empty!");
                }

                if (!string.IsNullOrEmpty(uem.UserName))
                {
                    appUser.UserName = uem.UserName;
                }
                else
                {
                    ModelState.AddModelError("", "User name cannot be empty!");
                }

                appUser.Active = uem.Active;
                appUser.Timezone = uem.Timezone;

                if (!string.IsNullOrEmpty(uem.Email) && !string.IsNullOrEmpty(uem.Password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(appUser);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        Errors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found!");
            }

            return View(appUser);
        }

        public IActionResult Delete(string id) 
        {
            var user = _userManager.Users.FirstOrDefault(a => a.Id == id);
            return View(user);
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {

                var result = await _userManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Errors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found!");
            }

            return RedirectToAction(nameof(Index));
        }

        

        public async Task<IActionResult> AddRolesToUser(string id)
        {
            ViewBag.UserId = id;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.Error = $"User with id - {id} cannot be found!";
                return View("PageNotFound");
            }

            ViewBag.UserName = user.UserName;
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

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRolesToUser(List<AddRemoveUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.Error = $"User with id - {userId} cannot be found!";
                return View("PageNotFound");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove roles from existing user");

                return View(model);
            }

            result = await _userManager.AddToRolesAsync
                (user, model.Where(role => role.Selected == true)
                .Select(role => role.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult SearchByQueryString(string s, string orderBy = "asc", int perPage = 0)
        {
            try
            {
                var users = _administrationRepository.QueryStringFilterUsers(s, orderBy, perPage);

                return View(users);
            }
            catch (Exception)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes", new { source = "No user in database!" });
            }
        }

        private void Errors(IdentityResult identityResult)
        {
            foreach (IdentityError error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

        }
    }
}
