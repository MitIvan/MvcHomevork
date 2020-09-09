using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = new List<PizzaViewModel>();
            foreach (var pizza in pizzas)
            {
                pizzaViewModels.Add(PizzaMapper.ToPizzaViewModel(pizza));
            }
            return View(pizzaViewModels); // returns ViewResult
        }

        public IActionResult CreatePizza()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();

            return View(pizzaViewModel);
        }

        [HttpPost]
        public IActionResult CreatePizzaPost(PizzaViewModel pizzaViewModel)
        {
            pizzaViewModel.Id = ++StaticDb.PizzaId;

            StaticDb.Pizzas.Add(PizzaMapper.ToPizza(pizzaViewModel));

            return RedirectToAction("Index");
        }

        public IActionResult EditPizza(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return View("ResourceNotFound");
            }

            PizzaViewModel pizzaViewModel = PizzaMapper.ToPizzaViewModel(pizza);

            return View(pizzaViewModel);
        }

        [HttpPost]
        public IActionResult EditPizzaPost(PizzaViewModel pizzaViewModel)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(p => p.Id == pizzaViewModel.Id);

            if (pizza == null)
            {
                return View("ResourceNotFound");
            }

            Pizza editedPizza = PizzaMapper.ToPizza(pizzaViewModel);
            int index = StaticDb.Pizzas.IndexOf(pizza);
            StaticDb.Pizzas[index] = editedPizza;

            return RedirectToAction("Index");

        }


        public IActionResult DeletePizza(int? id)
        {
            if (id == null)
                return View("BadRequest");

            Order order = StaticDb.Orders.FirstOrDefault(p => p.Pizza.Id == id);

            if (order != null)
            {
                return View("PizzaIsOrdered");
            }

            PizzaViewModel pizzaViewModel = new PizzaViewModel();

            return View(pizzaViewModel);
        }

        public IActionResult DeletePizzaPost(PizzaViewModel pizzaViewModel)
        {
            var index = StaticDb.Pizzas.FindIndex(x => x.Id == pizzaViewModel.Id);

            if (index == -1)
                return View("ResourceNotFound");

            StaticDb.Pizzas.RemoveAt(index);
            return RedirectToAction("Index");
        }

    }
       
}