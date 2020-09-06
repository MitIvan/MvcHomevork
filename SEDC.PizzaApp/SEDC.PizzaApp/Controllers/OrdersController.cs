using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            List<Order> orders = StaticDb.Orders;
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (Order order in orders)
            {
                orderViewModels.Add(OrderMapper.OrderToViewModel(order));
            }
            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                
                return View("PageNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return View("PageNotFound");
            }

            OrderViewModel orderViewModel = OrderMapper.OrderToDetailsViewModel(order);

            return View(orderViewModel);
           
        }

        //public IActionResult JsonData()
        //{
        //    Order order = StaticDb.Orders[0];

        //    return new JsonResult(order);
        //}

        //public IActionResult Redirect()
        //{
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
