using MediEval.Data;
using MediEval.Data.Static;
using MediEval.Data.ViewModel;
using MediEval.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using MediEval.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MediEval.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly UrlEncoder _urlEncoder;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, UrlEncoder urlEncoder, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
            _urlEncoder = urlEncoder;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync(); //Only By Admin
            return View(users);
        }

        [AllowAnonymous]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Medicine");
                    }
                    if (result.IsLockedOut)
                    {
                        return View("Lockout");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

        /**
         * ---------- Register ViewModel/ActionResult ------
         * **/

        [AllowAnonymous]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }

        /** --- Log Out --- **/

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Medicine");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        /******* --- Forgot Password --- ********/


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email, "Reset Password - Identity Manager",
                    "Please reset your password by clicking here: <a href=\"" + callbackurl + "\">link</a>");

                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            return View(model);
        }

        /********** --- Forgot Password --- ***********/

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


    }
}
