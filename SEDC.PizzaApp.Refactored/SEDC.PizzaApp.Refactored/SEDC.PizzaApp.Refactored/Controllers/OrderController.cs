using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Implementations;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Order;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        public IActionResult Index()
        {
            List<OrderDetailsViewModel> orderDetailsViewModels = _orderService.GetAllOrders();
            return View(orderDetailsViewModels);
        }
    }
}
  