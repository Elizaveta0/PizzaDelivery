using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public interface IPizzaManager
    {
        Task CreatePizza(Pizza pizza);

        Task UpdatePizza(Pizza pizza);

        Task DeletePizza(int id);

        Pizza Get(int id);

        List<Pizza> Get();

    }
}

