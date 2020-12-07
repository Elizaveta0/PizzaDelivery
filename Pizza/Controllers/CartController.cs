using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Database.Managers;
using Pizza.Models;
using Pizza.Models.ViewModels;
using Pizza.Services;

namespace Pizza.Controllers
{
    public class CartController : Controller
    {
        private IPizzaManager _pizzaManager;
        private IOrderManager _orderManager;
        private ICartManager _cartManager;
        private EmailService _emailService;
        private UserManager<IdentityUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public CartController(IPizzaManager pizzaManager, IOrderManager orderManager, ICartManager cartManager, 
            EmailService emailService, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _pizzaManager = pizzaManager;
            _orderManager = orderManager;
            _cartManager = cartManager;
            _emailService = emailService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public ActionResult Index()
        {
            return View(_cartManager.GetCart()
                .Select(x => new CartItemModel
                {
                    Price = _pizzaManager.GetPizzaPrice(x.PriceId),
                    Quantity = x.Quantity
                }).ToList());
        }
        public ActionResult RemoveFromCart(int id)
        {
            _cartManager.RemoveFromCart(id);
            return RedirectToAction("Index", "Cart");
        }

        public async Task<ActionResult> ConfirmCart()
        {
            var cart = _cartManager.GetCart();
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var order = new Order
            {
                Confirmed = false,
                Pizzas = cart.Select(x => new OrderPizza
                {
                    Pizza = _pizzaManager.GetPizzaPrice(x.PriceId),
                    Quantity = x.Quantity
                }).ToList(),
                User = await _userManager.FindByIdAsync(id),
            };
            await _orderManager.CreateOrder(order);
            var pizzaStr = "";
            foreach (var pizza in order.Pizzas)
            {
                pizzaStr += $"{pizza.Pizza.Pizza.Name} x {pizza.Quantity}\n\tPrice: ${pizza.Quantity * pizza.Pizza.SizePrice:N2}\n";
            }
            pizzaStr += "-----------------------------------------\nTotal: $" + order.Pizzas.Sum(x => x.Quantity * x.Pizza.SizePrice).ToString("N2");
            await _emailService.SendEmailAsync(order.User.Email, "Order created", pizzaStr);
            _cartManager.ClearCart();
            return RedirectToAction("Index", "Pizza");
        }
        public ActionResult ClearCart()
        {
            _cartManager.ClearCart();
            return RedirectToAction("Index", "Pizza");
        }
    }
}
