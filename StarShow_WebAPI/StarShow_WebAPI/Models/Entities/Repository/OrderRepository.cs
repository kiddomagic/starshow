using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrder(string id)
        {
            var order = new Order();
            using (var context = new Entities.StarShowDBEntities())
            {
                order = context.Orders.Where(a => a.id == id).FirstOrDefault();
            }
            return order;
        }

        public void UpdateOrder(Order order)
        {
            using (var context = new Entities.StarShowDBEntities())
            {
                order = context.Orders.Add(order);
            }
        }
    }
}