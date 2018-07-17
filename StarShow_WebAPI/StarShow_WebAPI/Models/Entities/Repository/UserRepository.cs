using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarShow_WebAPI.Models.Entities.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool SignIn(string username, string password)
        {
            using (var context = new Entities.StarShowDBEntities())
            {
                var signedIn = context.Users.Where(q => q.email == username).FirstOrDefault();
                if (signedIn.password == "ONLINE" || signedIn.password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SignUp(User user)
        {
            List<User> users;
            using (var context = new Entities.StarShowDBEntities())
            {
                users = context.Users.ToList();
                foreach (var item in users)
                {
                    if (user == item)
                    {
                        return false;
                    }
                }
                var newUser = context.Users.Add(user);
            }
            return true;
        }
    }
}