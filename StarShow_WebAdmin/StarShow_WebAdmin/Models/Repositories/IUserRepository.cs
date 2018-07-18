using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShow_WebAdmin.Models.Repositories
{
    interface IUserRepository
    {
        List<User> GetUsers();
        void AddUser(User user);
    }
}
