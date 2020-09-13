using SEDC.PizzaApp.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();
    }
}
