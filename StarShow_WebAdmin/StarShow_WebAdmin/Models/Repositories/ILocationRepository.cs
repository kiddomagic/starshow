using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAdmin.Models.Repositories
{
    interface ILocationRepository
    {
        void UpdateLocation(Location location);
        void AddLocation(Location location);
        bool DeleteLocation(Location location);
        List<Location> GetLocations();
        Location GetLocation(string id);
    }
}
