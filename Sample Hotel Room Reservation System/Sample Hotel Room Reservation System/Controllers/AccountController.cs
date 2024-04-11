using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample_Hotel_Room_Reservation_System.Databases;
using Sample_Hotel_Room_Reservation_System.Models;
using System.Threading.Tasks;

namespace Sample_Hotel_Room_Reservation_System.Controllers
{
    public class AccountController : Controller
    {
        // private readonly UserManager<User> _userManager;
        // private readonly SignInManager<User> _signInManager;

        private readonly Userservice services;


        public AccountController(Userservice services)
        {
            // _userManager = userManager;
            // _signInManager = signInManager;
            this.services=services;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Email = model.Email  };
                // var result = await _userManager.CreateAsync(user, model.Password);
                var result = services.addUser(user);

                if (result == "success")
                {
                    // await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home"); // Redirect to homepage after successful registration
                }

                // foreach (var error in result.Errors)
                // {
                //     ModelState.AddModelError(string.Empty, error.Description);
                // }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                // var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);

                var result = services.login(model.Username, model.Password);

                if (result=="success")
                {
                    return RedirectToAction("Index", "Home"); // Redirect to homepage after successful login
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Redirect to homepage after logout
        }
    }
}
