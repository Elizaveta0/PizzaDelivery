using Microsoft.EntityFrameworkCore;
using Pizza.Database;
using Pizza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Models;
using Pizza.Models.ViewModels;

namespace Pizza.Database.Managers
{

    public class PizzaManager: IPizzaManager
    {
        private ApplicationDbContext context;
        public PizzaManager(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task CreatePizza(Models.Pizza pizza)
        {
            for (int i = 0; i < 4; i++)
                pizza.Prices[i].Size = (Size)i;
            context.Pizzas.Add(pizza);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePizza(Models.Pizza pizza)
        {
            if (pizza.Id == 0)
            {
                for (int i = 0; i < 4; i++)
                    pizza.Prices[i].Size = (Size)i;
                context.Pizzas.Add(pizza);
                await context.SaveChangesAsync();
            }
            else
            {
                var dbEntry = context.Pizzas.FirstOrDefault(p => p.Id == pizza.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = pizza.Name;
                    dbEntry.Description = pizza.Description;
                    dbEntry.Prices = pizza.Prices;
                }
                context.SaveChanges();
            }
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
        public Models.Pizza GetPizza(int id)
        {
            return context.Pizzas.Include(x => x.Prices).Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public List<Models.Pizza> GetPizza()
        {
            return context.Pizzas.Include(x => x.Prices).ToList();
        }
        public Price GetPizzaPrice(int id)
        {
            return context.Prices.Include(x => x.Pizza).FirstOrDefault(x => x.Id == id);
        }
    }

}
