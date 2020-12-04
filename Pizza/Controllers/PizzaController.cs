using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.Models;

namespace Pizza.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaManager pizzaManager;
        public PizzaController([FromServices] IPizzaManager pizzaManager)
        {
            this.pizzaManager = pizzaManager;
        }
        // GET: PizzaControllers
        public ActionResult Index()
        {
            return View(pizzaManager.Get());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreatePizza(Models.Pizza pizza)
        {
            await pizzaManager.CreatePizza(pizza);
            return RedirectToAction("Index", "Pizza");
        }

    }
}
