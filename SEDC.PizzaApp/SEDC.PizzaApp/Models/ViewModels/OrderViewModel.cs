using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string PizzaName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
