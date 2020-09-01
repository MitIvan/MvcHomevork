using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string PizzaType { get; set; }

        public int Price { get; set; }

    }
}
