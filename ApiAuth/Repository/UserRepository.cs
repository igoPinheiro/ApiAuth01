using ApiAuth.Models;
using System.Reflection.Metadata.Ecma335;

namespace ApiAuth.Repository
{
    public static class UserRepository
    {
        public static User? Get(string username, string password)
        {
            var users = new List<User>()
            {
               new User { Id = 1, UserName = "batman", Password = "123", Role="manager"},
            new User { Id = 2, UserName = "robin", Password = "123", Role = "employee" }

            };

            //return users
            //    .Where(x => x.UserName.ToLower()== username.ToLower() && x.Password == password)
            //    .FirstOrDefault();

            return users
                .FirstOrDefault(u=> 
                   u.UserName==username
                   && u.Password == password);
        }
    }
}
