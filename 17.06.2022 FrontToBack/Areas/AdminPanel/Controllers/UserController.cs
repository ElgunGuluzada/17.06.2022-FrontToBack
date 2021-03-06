using _17._06._2022_FrontToBack.Models;
using _17._06._2022_FrontToBack.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static _17._06._2022_FrontToBack.Helpers.Helper;

namespace _17._06._2022_FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            UserVM userVM = new UserVM();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                //var roles = _rolemanager.Roles.ToList();
                userVM.Users = users;
                userVM.userRoles = userRoles;
                //userVM.Roles = roles;
                userVM.UserId = user.Id;
            }
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(userVM);
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _rolemanager.Roles.ToList();
            RoleVM rolevm = new RoleVM
            {
                FullName = user.Fullname,
                roles = roles,
                userRoles = userRoles,
                UserId = user.Id
            };

            return View(rolevm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(List<string> roles, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            //var addRoles=roles.Except(userRoles);
            //var removedRoles=userRoles.Except(roles);
            //await _userManager.AddToRolesAsync(user,addRoles);
            //await _userManager.RemoveFromRolesAsync(user, removedRoles);


            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, roles);

            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            DateTime now = DateTime.Now;
            DateTime confirm = now.AddMinutes(1);
            AppUser user = new AppUser
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
                UserCreateTime = now,
                ConfirmMailTime = confirm,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }
            await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());
            return RedirectToAction("index","user");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (user.EmailConfirmed==false)
            {
                await _userManager.DeleteAsync(user);
            }
            else
            {
                return Content("Silmek Olmaz");
            }
            return RedirectToAction("index");
        }
    }
}
