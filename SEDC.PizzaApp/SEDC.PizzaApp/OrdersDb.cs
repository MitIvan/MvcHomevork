using SEDC.PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public static class OrdersDb
    {
        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                PizzaType = "Capri",
                Price = 300
                
            },         
            new Order()
            {
                Id = 2,
                PizzaType = "Margarita",
                Price = 250
                
            }
        };
    }
}
