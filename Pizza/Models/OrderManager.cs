using Microsoft.EntityFrameworkCore;
using Pizza.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class OrderManager
    {
        private ApplicationDbContext context;
        public OrderManager(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task CreateOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }
        public async Task UpdateOrder(Order order)
        {
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                var dbEntry = context.Orders.Include(x => x.Pizzas).FirstOrDefault(p => p.Id == order.Id);
                if (dbEntry != null)
                {
                    dbEntry.Pizzas = order.Pizzas;
                }
            }
        }
        public async Task DeleteOrder(int id)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }

        }
        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> Get()
        {
            return context.Orders.Include(x => x.Pizzas).ToList();
        }
    }
}

