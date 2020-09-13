using SEDC.PizzaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string PizzaStore { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
