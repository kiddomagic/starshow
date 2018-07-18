using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAdmin.Models.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        public void AddSlot(Slot slot)
        {
            using (var context = new StarShowDBEntities())
            {
                context.Slots.Add(slot);                
            }
        }

        public bool DeleteSlot(Slot slot)
        {
            using (var context = new StarShowDBEntities())
            {
                context.Slots.Remove(slot);
            }
            return true;
        }

        public Slot GetSlot(string id)
        {
            Slot slot;
            using (var context = new StarShowDBEntities())
            {
                slot = context.Slots.Where(q => q.id == id).FirstOrDefault();
            }
            return slot;
        }

        public List<Slot> GetSlots()
        {
            List<Slot> slots;
            using (var context = new StarShowDBEntities())
            {
                slots = context.Slots.ToList();
            }
            return slots;
        }

        public void UpdateSlot(Slot slot)
        {
            using (var context = new StarShowDBEntities())
            {
                Slot _slot = context.Slots.Where(q => q.id == slot.id).FirstOrDefault();
                _slot = slot;
                context.SaveChanges();
            }
        }
    }
}