using Microsoft.EntityFrameworkCore;
using Pizza.Database;
using Pizza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{

    public class PizzaManager: IPizzaManager
    {
        private ApplicationDbContext context;
        public PizzaManager(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task CreatePizza(Pizza pizza)
        {
            for (int i = 0; i < 4; i++)
                pizza.Prices[i].Size = (Size)i;
            context.Pizzas.Add(pizza);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePizza(Pizza pizza)
        {
            if (pizza.Id == 0)
            {
                for (int i = 0; i < 4; i++)
                    pizza.Prices[i].Size = (Size)i;
                context.Pizzas.Add(pizza);
            }
            else
            {
                var dbEntry = context.Pizzas.Include(x => x.Prices).FirstOrDefault(p => p.Id == pizza.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = pizza.Name;
                    dbEntry.Description = pizza.Description;
                    dbEntry.Prices = pizza.Prices;
                }
            }
            await context.SaveChangesAsync();
        }
        public async Task DeletePizza(int id)
        {
            var pizza = context.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                context.Pizzas.Remove(pizza);
                await context.SaveChangesAsync();
            }

        }
        public Pizza Get(int id)
        {
            return context.Pizzas.Include(x => x.Prices).FirstOrDefault(x => x.Id == id);
        }

        public List<Pizza> Get()
        {
            return context.Pizzas.Include(x => x.Prices).ToList();
        }
    }

}
