using Pizza.Models;
using Pizza.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Database.Managers
{
    public interface ICartManager
    {
        void AddToCart(CartItem cartItem);
        void RemoveFromCart(int pizzaId);
        List<CartItem> GetCart();
        void ClearCart();
    }
}
