using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    public class ShowRepository : IShowRepository
    {
        public List<Show> shows;

        public Show GetShowById(string id)
        {
            var show = new Show();
            using (var context = new Entities.StarShowDBEntities())
            {
                show = context.Shows.Where(a => a.id == id).FirstOrDefault();
            }
            return show;
        }

        public List<Show> GetShows()
        {
            using ( var context = new Entities.StarShowDBEntities() )
            {
                shows = context.Shows.ToList();
            }
            return shows;
        }
    }
}