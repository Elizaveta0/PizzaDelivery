using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<OrderPizza> Pizzas { get; set; } 
    }
}
