using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAdmin.Models.Repositories
{
    interface ISlotRepository
    {
        Slot GetSlot(string id);
        List<Slot> GetSlots();
        void AddSlot(Slot slot);
        void UpdateSlot(Slot slot);
        bool DeleteSlot(Slot slot);
    }
}
