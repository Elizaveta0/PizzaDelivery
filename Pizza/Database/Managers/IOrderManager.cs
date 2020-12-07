using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Database.Managers
{
    public interface IOrderManager
    {
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
        Order GetOrder(int id); 
        List<Order> GetOrder();
    }
}
