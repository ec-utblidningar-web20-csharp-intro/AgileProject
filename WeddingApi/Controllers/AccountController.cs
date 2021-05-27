using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models.Couple;
using WeddingApi.ViewModels;

namespace WeddingApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public class RegisterInput
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("FirstName, LastName," +
            "Email, Password, PhoneNumber")] RegisterPersonViewModel input)
        {
            var person = new Person { UserName = input.Email, Email = input.Email };
            var tryCreateNewPerson = await _userManager.CreateAsync(person, input.Password);
            if (tryCreateNewPerson.Succeeded)
            {
                await _signInManager.SignInAsync(person, false);
                //någon annan view här. 
                return View("Register");
            }
            return View("Register");
        }

        public IActionResult Login()
        {
            return View();
        }

        
    }

}
