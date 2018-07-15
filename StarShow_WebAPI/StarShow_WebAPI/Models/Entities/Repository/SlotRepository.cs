using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    public class SlotRepository : ISlotRepository
    {
        public DateTime GetSlotDate(string id)
        {
            var date = new DateTime();
            using (var context = new Entities.StarShowDBEntities())
            {
                date = context.Slots.Where(a => a.id == id).FirstOrDefault().date.Value;
            }
            return date;
        }
    }
}