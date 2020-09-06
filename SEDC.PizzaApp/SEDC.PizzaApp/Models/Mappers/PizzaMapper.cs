using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel PizzaToViewModel(Pizza pizza)
        {
            if (pizza.HasExtras)
            {
                return new PizzaViewModel
                {
                    Id = pizza.Id,
                    PizzaName = pizza.PizzaName,
                    Price = pizza.Price + 10,
                    PizzaSize = pizza.PizzaSize
                };
            }
            else
            {
                return new PizzaViewModel
                {
                    Id = pizza.Id,
                    PizzaName = pizza.PizzaName,
                    Price = pizza.Price,
                    PizzaSize = pizza.PizzaSize
                };
            }

        }
    }
}
