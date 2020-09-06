using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel OrderToViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Price = order.Pizza.Price,
                PizzaName = order.Pizza.PizzaName,
            };
        }

        public static OrderViewModel OrderToDetailsViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Price = order.Pizza.Price,
                PizzaName = order.Pizza.PizzaName,
                FullName = $"{order.User.FirstName} {order.User.LastName}",
                Address = order.User.Address
            };
        }
    }
}
