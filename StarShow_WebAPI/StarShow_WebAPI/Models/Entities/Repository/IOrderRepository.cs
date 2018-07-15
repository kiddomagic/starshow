using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    interface IOrderRepository
    {
        void UpdateOrder(Order order);
        Order GetOrder(string id);        
    }
}
