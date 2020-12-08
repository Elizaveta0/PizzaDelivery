using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Database.Managers;
using Pizza.Models.ViewModels;

namespace Pizza.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private ICartManager _cartManager;

        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ICartManager cartManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartManager = cartManager;

        }
        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Pizza");
            return View();
        }
        public ActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Pizza");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpModel signUpModel)
        {
            var user = new IdentityUser
            {
                UserName = signUpModel.Username,
                Email = signUpModel.Email,
                PhoneNumber = signUpModel.Phone
            };
            var createResult = await _userManager.CreateAsync(user, signUpModel.Password);
            var userClaims = new Claim(ClaimTypes.Role, "User");
            var claimResult = await _userManager.AddClaimAsync(user, userClaims);
            return RedirectToAction("Index", "Pizza");
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Pizza");
            }
            else
            {
                return View();
            }
        }

        //[HttpPost]
        public async Task<ActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            _cartManager.ClearCart();
            return RedirectToAction("Index", "Pizza");
        }

    }
}
