using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAdmin.Models.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public bool DeleteLocation(Location location)
        {
            using (var context = new StarShowDBEntities())
            {
                context.Locations.Remove(location);
            }
            return true;
        }

        public Location GetLocation(string id)
        {
            Location location;
            using (var context = new StarShowDBEntities())
            {
                location = context.Locations.Where(q => q.id == id).FirstOrDefault();
            }
            return location;
        } 
        public List<Location> GetLocations()
        {
            List<Location> locations;
            using (var context = new StarShowDBEntities())
            {
                locations = context.Locations.ToList();
            }
            return locations;
        }

        public void AddLocation(Location location)
        {            
            using (var context = new StarShowDBEntities())
            {
                context.Locations.Add(location);
            }            
        }

        public void UpdateLocation(Location location)
        {
            using (var context = new StarShowDBEntities())
            {
                Location l = context.Locations.Where(q => q.id == location.id).FirstOrDefault();
                l = location;
                context.SaveChanges();
            }
        }
    }
}