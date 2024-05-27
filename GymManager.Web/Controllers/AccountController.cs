using Microsoft.AspNetCore.Identity;
using GymManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymManager.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController (SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            if(!_userManager.Users.Any()){
                var result = _userManager.CreateAsync(new IdentityUser 
                {Email = "isaac.est.cbtis@gmail.com",
                UserName = "isaac.est.cbtis@gmail.com",
                EmailConfirmed = true,
                }, "p@Sswd1").Result;
                Console.WriteLine("pues ya estaria registrado bro");
                Console.WriteLine($"el result es: {result}");
            }else{
                Console.WriteLine("no se registrara ni piter");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model){
            string returnUrl = string.IsNullOrEmpty(Request.Query["returnUrl"]) ?
            Url.Content("~/") : Request.Query["returnUrl"];

            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync
                (model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if(result.Succeeded) {
                    return LocalRedirect(returnUrl);
                }
                if(result.IsLockedOut){
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                }
            }
            return View();
        }

    }
}