using SEDC.PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Pizza Name")]
        public string PizzaName { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Pizza Size")]
        public PizzaSize pizzaSize { get; set; }
        public bool HasExtras { get; set; }
    }
}
