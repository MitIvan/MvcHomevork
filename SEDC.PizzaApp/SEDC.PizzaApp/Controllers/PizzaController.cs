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
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Pizzas List";

            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = new List<PizzaViewModel>();
            foreach(Pizza pizza in pizzas)
            {
                pizzaViewModels.Add(PizzaMapper.PizzaToViewModel(pizza));
            };
            return View(pizzaViewModels);
        }

        public IActionResult Details(int? id)
        {
            ViewData["Title"] = "Pizza Details";

            ViewBag.Pizza = StaticDb.Pizzas.FirstOrDefault(p => p.Id == id);
            if (id == null)
            {
                return new EmptyResult();
            }

            //Pizza pizza = StaticDb.Pizzas.FirstOrDefault(p => p.Id == id);
            //if (pizza == null)
            //{
            //    return new EmptyResult();
            //}

            //PizzaViewModel pizzaViewModel = PizzaMapper.PizzaToViewModel(pizza);

            return View();
        }
        
        [HttpGet("SeePizzas")]
        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var pizza = StaticDb.Pizzas.First();
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            return RedirectToAction("Index");
        }
    }
}