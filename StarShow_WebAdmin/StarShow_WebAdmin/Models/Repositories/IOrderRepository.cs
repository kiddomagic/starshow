using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAdmin.Models.Repositories
{
    interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrder(string id);
        bool DeleteOrder(Order order);
    }
}
