using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class OrderPizza
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Price Pizza { get; set; }
        public int Quantity { get; set; }
    }
}
