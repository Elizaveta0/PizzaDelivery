using Microsoft.AspNetCore.Mvc;
using Pizza.Database.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private ICartManager _cartManager;

        public CartViewComponent(ICartManager cartManager)
        {
            _cartManager = cartManager;

        }

        public IViewComponentResult Invoke()
        {
                return View("Cart", _cartManager.GetCart());
        }
    }
}
