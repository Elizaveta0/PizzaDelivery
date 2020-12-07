using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Database;
using Pizza.Database.Managers;
using Pizza.Models.ViewModels;

namespace Pizza.Controllers
{
    [Authorize(Policy = "ManagerOnly")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private IPizzaManager _pizzaManager;
        private IOrderManager _orderManager;
        private IAuthorizationService _auth;

        public AdminController(UserManager<IdentityUser> userManager, IPizzaManager pizzaManager, IOrderManager orderManager, IAuthorizationService auth)
        {
            _userManager = userManager;
            _pizzaManager = pizzaManager;
            _orderManager = orderManager;
            _auth = auth;
        }
        public ActionResult Users()
        {
            return View(_userManager.Users.ToList());
        }
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult> EditUser(IdentityUser usr, string role)
        {
            var user = await _userManager.FindByIdAsync(usr.Id);
            user.Email = usr.Email;
            user.UserName = usr.UserName;
            user.PhoneNumber = usr.PhoneNumber;
            await _userManager.UpdateAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            await _userManager.RemoveClaimsAsync(user, claims.Where(x => x.Type == ClaimTypes.Role));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
            return RedirectToAction("Users", "Admin");
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Users", "Admin");
        }
        [Authorize(Policy = "AdminOnly")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(SignUpModel model, string role)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            var createResult = await _userManager.CreateAsync(user, model.Password);
            var userClaims = new Claim(ClaimTypes.Role, role);
            var claimResult = await _userManager.AddClaimAsync(user, userClaims);
            return RedirectToAction("Users", "Admin");
        }

        public ActionResult Pizzas()
        {
            return View(_pizzaManager.GetPizza());
        }
        public ActionResult EditPizza(int id)
        {
            return View(_pizzaManager.GetPizza(id));
        }
        [HttpPost]
        public ActionResult EditPizza(Models.Pizza pizza)
        {
            _pizzaManager.UpdatePizza(pizza);
            return RedirectToAction("Pizzas", "Admin");
        }

        public async Task<ActionResult> DeletePizza(int id)
        {
            await _pizzaManager.DeletePizza(id);
            return RedirectToAction("Pizzas", "Admin");
        }
        public ActionResult CreatePizza()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreatePizza(Models.Pizza pizza)
        {
            await _pizzaManager.CreatePizza(pizza);
            return RedirectToAction("Pizzas", "Admin");
        }
        public ActionResult Orders()
        {
            return View(_orderManager.GetOrder());
        }
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _orderManager.DeleteOrder(id);
            return RedirectToAction("Orders", "Admin");
        }
        public async Task<ActionResult> MarkOrderAsConfirmed(int id)
        {
            var order = _orderManager.GetOrder(id);
            order.Confirmed = true;
            await _orderManager.UpdateOrder(order);
            return RedirectToAction("Orders", "Admin");
        }
    }
}
