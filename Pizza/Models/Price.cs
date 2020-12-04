using Pizza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class Price
    {
        public int Id { get; set; }
        public Size Size  { get; set; }
        public double SizePrice { get; set; }
        public Pizza Pizza { get; set; } 
        public ICollection<OrderPizza> Orders { get; set; }
    }
}
