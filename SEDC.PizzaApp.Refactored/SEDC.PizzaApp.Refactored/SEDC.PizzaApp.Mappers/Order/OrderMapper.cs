using SEDC.PizzaApp.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.Domain.Models;
using System.Linq;

namespace SEDC.PizzaApp.Mappers.Order
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Domain.Models.Order order)
        {
            double price = 0;
            price = order.PizzaOrders.Select(x => x.Price += price).Sum();
             
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                PizzaStore = order.PizzaStore,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList(),
                Price = price
            };
        }
    }
}
