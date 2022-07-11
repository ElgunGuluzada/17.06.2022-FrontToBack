using _17._06._2022_FrontToBack.Models;
using _17._06._2022_FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace _17._06._2022_FrontToBack.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
        }

        public IActionResult Index()    
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("register", "account");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            DateTime now = DateTime.Now;
            DateTime confirm = now.AddMinutes(5);
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


            return RedirectToAction("login","account");

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.FindByEmailAsync(login.Email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "email or  password is invalid!");
                return View(login);
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, login.Password, true, true);

            TimeSpan time = appUser.ConfirmMailTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
            var time2 = TimeSpan.FromMinutes(time.TotalMinutes);
            int m = time2.Minutes;
            var s = time2.Seconds;
            if (s <= 0 && appUser.EmailConfirmed == false)
            {
                await _signInManager.SignOutAsync();
                await _userManager.DeleteAsync(appUser);
                ModelState.AddModelError("","Email Reset! You can use this email again!");
                return View(login);
            }
            else if (appUser.EmailConfirmed==true&&result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, true);
                return RedirectToAction("Index", "home");
            }
            ViewBag.Failed = appUser.AccessFailedCount;
            ViewBag.Success=result.Succeeded;
            ViewBag.Email = appUser.EmailConfirmed;
            TempData["User Create Time"] = appUser.UserCreateTime;
            TempData["IsConfirmTime"] = appUser.ConfirmMailTime;
            TempData["QalanVaxt"] = $"{m} deq {s}san erzinde mailinizi tesdiqleyin";

            if (result.IsLockedOut)
            {
                TimeSpan timeSpan = appUser.LockoutEnd.Value.UtcDateTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
                var timeSpanFromMinutes = TimeSpan.FromMinutes(timeSpan.TotalMinutes);
                int mm = timeSpanFromMinutes.Minutes;
                int ss = timeSpanFromMinutes.Seconds;
                TempData["Error"] = $"{mm} deq {ss} saniye sonra daxil ola bilersiniz";
                return View(login);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "email or  password is invalid!");
                return View(login);
            }
            if (result==null)
            {
                ModelState.AddModelError("", "email or  password is invalid!");
                return View(login);
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //var curUser = await _userManager.GetUserAsync(HttpContext.User);
            //await _userManager.DeleteAsync(curUser);
            return RedirectToAction("index", "home");

        }
    }
}
