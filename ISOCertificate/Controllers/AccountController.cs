using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISOCertificate.DAL;
using ISOCertificate.Models;
using ISOCertificate.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ISOCertificate.Controllers
{
    public class AccountController : Controller
    {
        private readonly CertificateDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _myroot;

        public AccountController(CertificateDbContext dbContext,
                                 UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IHostingEnvironment myroot)
        {
            _db = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _myroot = myroot;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            ApplicationUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Email or Password is invalid");
                return View(loginViewModel);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                  await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure:true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("Email", "Email or password is invalid");
                return View(loginViewModel);
            }
            HttpContext.Session.SetString("Email", loginViewModel.Email);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Login", "Account");
        }
    }
}