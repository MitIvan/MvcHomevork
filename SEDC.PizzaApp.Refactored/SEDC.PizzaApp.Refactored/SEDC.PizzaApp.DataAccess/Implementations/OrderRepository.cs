using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            StaticDb.OrderId++;
            entity.Id = StaticDb.OrderId;
            StaticDb.Orders.Add(entity);

            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if(order == null)
            {
                throw new Exception($"Order with id {entity.Id} was not found");
            }

            int index = StaticDb.Orders.IndexOf(order);
            StaticDb.Orders[index] = entity;
        }

        public void DeleteById(int id)
        {
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                throw new Exception($"Order with id {id} was not found");
            }

            StaticDb.Orders.Remove(order);
 
        }
    }
}
