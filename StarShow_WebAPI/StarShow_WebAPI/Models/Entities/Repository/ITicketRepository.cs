using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    interface ITicketRepository
    {
        Slot GetSlotById(string userId, string showName);
        Order GetOrderById(string userId, string showName);
        double GetPrice(string userId, string showName);
    }
}
