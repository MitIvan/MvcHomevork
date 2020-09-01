using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if(id != null)
            {
                Order order = OrdersDb.Orders.FirstOrDefault(o => o.Id == id);
                return View(order);
            }
            else
            {
                return new EmptyResult();
            }
        }

        public IActionResult JsonData()
        {
            Order order = OrdersDb.Orders[0];

            return new JsonResult(order);
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
