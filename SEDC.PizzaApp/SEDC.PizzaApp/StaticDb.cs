using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp
{
    public class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza()
            {
                Id=1,
                PizzaName = "Capri",
                Price = 370,
                HasExtras = false,
                IsOnPromotion = true,
                PizzaSize = PizzaSize.Medium,
                
               
                

            },
            new Pizza()
            {
                Id=2,
                PizzaName="Margarita",
                Price = 300,
                HasExtras = true,
                IsOnPromotion = false,
                PizzaSize = PizzaSize.Large
            },
            new Pizza()
            {
                Id=3,
                PizzaName="Pepperoni",
                Price = 400,
                HasExtras = false,
                IsOnPromotion = false,
                PizzaSize = PizzaSize.Samll
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                Pizza = new Pizza
                {
                    Id=2,
                    PizzaName="Margarita",
                    Price = 300,
                    HasExtras = true,
                    IsOnPromotion = false,
                    PizzaSize = PizzaSize.Large
                },
                User = new User
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Mitev",
                    Address = "Address1111"
                },
                PaymentMethod = PaymentMethod.Card

            },
            new Order()
            {
                Id = 2,
                Pizza = new Pizza
                {
                    Id=3,
                    PizzaName="Pepperoni",
                    Price = 400,
                    HasExtras = false,
                    IsOnPromotion = false,
                    PizzaSize = PizzaSize.Samll
                },
                User = new User
                {
                    Id = 2,
                    FirstName = "Davor",
                    LastName = "Mitev",
                    Address = "Address1111"
                },
                PaymentMethod = PaymentMethod.Cash
            }
        };
    }
}
