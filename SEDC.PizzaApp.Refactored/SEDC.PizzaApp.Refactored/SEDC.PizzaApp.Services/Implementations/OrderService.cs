using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Order;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<OrderDetailsViewModel> viewModels = new List<OrderDetailsViewModel>();
            foreach (Order order in orders)
            {
                viewModels.Add(order.ToOrderDetailsViewModel());
            }

            return viewModels;
            
        }
    }
}
