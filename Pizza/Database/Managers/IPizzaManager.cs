using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Database.Managers
{
    public interface IPizzaManager
    {
        Task CreatePizza(Models.Pizza pizza);

        Task UpdatePizza(Models.Pizza pizza);

        Task DeletePizza(int id);

        Models.Pizza GetPizza(int id);

        List<Models.Pizza> GetPizza();
        Price GetPizzaPrice(int id);

    }
}

