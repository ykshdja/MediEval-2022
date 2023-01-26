using MediEval.Areas.Admin.Models;
using MediEval.Data.Static;
using MediEval.Data.ViewModel;
using MediEval.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Web.Providers.Entities;

namespace MediEval.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.Admin)]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> userMngr, RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            roleManager = roleMngr;
        }
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> appUsers = new List<ApplicationUser>();
            var users = await userManager.Users.ToListAsync();
            foreach (ApplicationUser user in users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                appUsers.Add(user);
            }

            UserViewModel model = new UserViewModel
            {
                Users = appUsers,
                Roles = roleManager.Roles
            };

            return View(model);
        }

        /**********--- DeletFromAdmin ---**************/


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        /**********--- Add ---**************/



        [HttpPost]
        public async Task<IActionResult> Add(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FullName = model.FullName,
                    Email = model.EmailAddress,
                    UserName = model.EmailAddress
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }


        /**********--- AddToAdmin ---**************/

        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist. "
                            + "Click 'Create Admin Role' button to create it.";
            }
            else
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }

            return RedirectToAction("Index");
        }

        /********** --- RemoveFromAdmin --- **************/


        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {

            ApplicationUser user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, "Admin");
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("Index");
        }

        /************ --- CreateAdminRole ---***********/

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("Index");
        }


        /************ --- DeleteRole ---***********/


        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("Index");
        }


    }
}
