using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAdmin.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public bool DeleteOrder(Order order)
        {
            using (var context = new StarShowDBEntities())
            {
                context.Orders.Remove(order);
            }
            return true;
        }

        public Order GetOrder(string id)
        {
            Order order;
            using (var context = new StarShowDBEntities())
            {
                order = context.Orders.Where(q => q.id == id).FirstOrDefault();
            }
            return order;
        }

        public List<Order> GetOrders()
        {
            List<Order> orders;
            using (var context = new StarShowDBEntities())
            {
                orders = context.Orders.ToList();
            }
            return orders;
        }
    }
}