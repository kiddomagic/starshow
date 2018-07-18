using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAdmin.Models.Repositories
{
    public class ShowRepository : IShowRepository
    {
        public void AddShow(Show show)
        {
            using (var context = new StarShowDBEntities())
            {
                context.Shows.Add(show);
            }
        }

        public bool DeleteShow(string id)
        {
            using (var context = new StarShowDBEntities())
            {
                Show show = context.Shows.Where(q => q.id == id).FirstOrDefault();
                show.status = 0;
                context.SaveChanges();
            }
            return true;
        }

        public Show GetShow(string id)
        {
            Show show;
            using (var context = new StarShowDBEntities())
            {
                show = context.Shows.Where(q => q.id == id && q.status != 0).FirstOrDefault();
            }
            return show;
        }

        public List<Show> GetShows()
        {
            List<Show> shows;
            using (var context = new StarShowDBEntities())
            {
                shows = context.Shows.Where(q => q.status != 0).ToList();
            }
            return shows;
        }

        public void UpdateShow(Show show)
        {
            using (var context = new StarShowDBEntities())
            {
                Show _show = context.Shows.Where(q => q.id == show.id).FirstOrDefault();
                _show = show;
                context.SaveChanges();
            }
        }
    }
}