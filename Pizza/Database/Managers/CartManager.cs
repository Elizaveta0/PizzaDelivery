using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Pizza.Models;
using Pizza.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Database.Managers
{
    public class CartManager : ICartManager
    {
        private ISession _session;

        public CartManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;

        }

        public void AddToCart(CartItem cartItem)
        {
            var sessionCart = _session.GetString("Cart") ?? "";
            var cart = JsonConvert.DeserializeObject<List<CartItem>>(sessionCart) ?? new List<CartItem>();
            if (cart.Any(x => x.PriceId == cartItem.PriceId))
                cart.FirstOrDefault(x => x.PriceId == cartItem.PriceId).Quantity += cartItem.Quantity;
            else
                cart.Add(cartItem);
            sessionCart = JsonConvert.SerializeObject(cart);
            _session.SetString("Cart", sessionCart);
        }

        public void RemoveFromCart(int pizzaId)
        {
            var sessionCart = _session.GetString("Cart") ?? "";
            var cart = JsonConvert.DeserializeObject<List<CartItem>>(sessionCart) ?? new List<CartItem>();
            if (cart.Any(x => x.PriceId == pizzaId))
                cart.RemoveAll(x => x.PriceId == pizzaId);
            sessionCart = JsonConvert.SerializeObject(cart);
            _session.SetString("Cart", sessionCart);
        }

        public void ClearCart()
        {
            _session.SetString("Cart", "");
        }

        public List<CartItem> GetCart()
        {
            var sessionCart = _session.GetString("Cart") ?? "";
            return JsonConvert.DeserializeObject<List<CartItem>>(sessionCart) ?? new List<CartItem>();
        }
    }
}
