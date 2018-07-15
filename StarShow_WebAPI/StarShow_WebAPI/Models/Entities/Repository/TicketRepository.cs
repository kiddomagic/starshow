using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public Order GetOrderById(string userId, string showName)
        {
            Order order = null;
            List<Order> orders;
            Slot slot;
            Show show;
            using (var context = new Entities.StarShowDBEntities())
            {
                show = context.Shows.Where(q => q.title == showName).FirstOrDefault();
                slot = context.Slots.Where(q => q.showId == show.id).FirstOrDefault();
                orders = context.Orders.Where(q => q.userId == userId).ToList();
            }
            foreach (var item in orders)
            {
                if (item.Tickets.Where(q => q.slotId == slot.id).FirstOrDefault().Order.buyTime.Value < slot.date.Value)
                {
                    order = item;
                    break;
                }
            }
            return order;
        }

        public double GetPrice(string userId, string showName)
        {
            Order order = null;
            List<Order> orders;
            Slot slot;
            Show show;
            using (var context = new Entities.StarShowDBEntities())
            {
                show = context.Shows.Where(q => q.title == showName).FirstOrDefault();
                slot = context.Slots.Where(q => q.showId == show.id).FirstOrDefault();
                orders = context.Orders.Where(q => q.userId == userId).ToList();
            }
            foreach (var item in orders)
            {
                if (item.Tickets.Where(q => q.slotId == slot.id).FirstOrDefault().Order.buyTime.Value < slot.date.Value)
                {
                    order = item;
                    break;
                }
            }
            return order.Tickets.Where(q => q.slotId == order.id).First().price.Value;
        }

        public Slot GetSlotById(string userId, string showName)
        {            
            Slot slot;
            Show show;
            using (var context = new Entities.StarShowDBEntities())
            {
                show = context.Shows.Where(q => q.title == showName).FirstOrDefault();
                slot = context.Slots.Where(q => q.showId == show.id).FirstOrDefault();                
            }
            return slot;
        }
    }
}