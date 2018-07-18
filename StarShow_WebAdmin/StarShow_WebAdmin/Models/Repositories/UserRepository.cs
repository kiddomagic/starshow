using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAdmin.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            using (var context = new StarShowDBEntities())
            {
                context.Users.Add(user);
            }
        }

        public List<User> GetUsers()
        {
            List<User> users;
            using (var context = new StarShowDBEntities())
            {
                users = context.Users.ToList();
            }
            return users;
        }
    }
}