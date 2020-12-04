using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Models.ViewModels;

namespace Pizza.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _manager;

        public AccountController (UserManager<IdentityUser> manager)
        {
            _manager = manager;
        }
        public ActionResult SignUp()
        {
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
            var createResult = await _manager.CreateAsync(user, signUpModel.Password);
            var managerClaims = new Claim("Role", "User");
            var claimResult = await _manager.AddClaimAsync(user, managerClaims);
            return RedirectToAction("Index", "Pizza");
        }

    }
}
