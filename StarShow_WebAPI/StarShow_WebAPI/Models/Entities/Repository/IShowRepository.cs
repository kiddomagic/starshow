using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    interface IShowRepository
    {
        List<Show> GetShows();
        Show GetShowById(string id);
    }
}
