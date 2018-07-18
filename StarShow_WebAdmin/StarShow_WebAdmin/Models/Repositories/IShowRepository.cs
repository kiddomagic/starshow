using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAdmin.Models.Repositories
{
    interface IShowRepository
    {
        Show GetShow(string id);
        List<Show> GetShows();
        void AddShow(Show show);
        void UpdateShow(Show show);
        bool DeleteShow(string id);
    }
}
