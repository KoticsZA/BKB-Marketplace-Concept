using BKBConcept.Interfaces;
using BKBConcept.Models;
using BKBConcept.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BKBConcept.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly UserManager<MyUser> _userManager;

        public AccountController(IAuthService authService, UserManager<MyUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authService.RegisterAsync(model);

            if (result.Succeeded)
                return RedirectToAction("Login");

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach(var error in ModelState.Values)
                {
                    ModelState.AddModelError("", $"There is an error of the type: {error}");
                    return View(model);
                }
            }

            var result = await _authService.LoginAsync(model);

            Console.WriteLine($"Succeeded: {result.Succeeded}");
            Console.WriteLine($"IsNotAllowed: {result.IsNotAllowed}");
            Console.WriteLine($"IsLockedOut: {result.IsLockedOut}");
            Console.WriteLine($"RequiresTwoFactor: {result.RequiresTwoFactor}");

            if (result.Succeeded)
            {
                var user = await _userManager.GetUserAsync(User);

                if(user.Role == "Client")
                {
                    return RedirectToAction("Index", "Client");
                }
                else if(user.Role == "Seller")
                {
                    return RedirectToAction("Index", "Seller");
                }
                else if(user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }

            return View(model);
        }
    }
}
