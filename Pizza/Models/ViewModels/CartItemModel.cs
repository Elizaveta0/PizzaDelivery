using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models.ViewModels
{
    public class CartItemModel
    {
        public Price Price { get; set; }
        public int Quantity { get; set; }
    }
}
