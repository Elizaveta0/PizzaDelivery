using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.Database.Managers;
using Pizza.Models.ViewModels;

namespace Pizza.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaManager _pizzaManager;
        private ICartManager _cartManager;

        public PizzaController(IPizzaManager pizzaManager, ICartManager cartManager)
        {
            _pizzaManager = pizzaManager;
            _cartManager = cartManager;
        }
        public ActionResult Index()
        {
            return View(_pizzaManager.GetPizza());
        }
        [Route("{id}")]
        public ActionResult Pizza(int id)
        {
            var pizza = _pizzaManager.GetPizza(id);
            if (pizza != null)
                return View(pizza);
            return RedirectToAction("Error", "Error", new { statusCode = 404 });
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int qty)
        {
            if (qty > 0)
                _cartManager.AddToCart(new CartItem
                {
                    PriceId = id,
                    Quantity = qty
                });
            return RedirectToAction("Index", "Pizza");
        }

    }
}
