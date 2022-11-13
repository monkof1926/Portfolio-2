using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.IDataService;


namespace DataLayer.DataService 
{
    public class UserDataService : IUserDataService
    {
        public void CreateUser(User user)
        {
            using var db = new NorthwindContext();
            db.users.Add(user);
            db.SaveChanges();
        }
        public bool DeleteUser(string username)
        {
            using var db = new NorthwindContext();
            var user = db.users.Find(username);
            if (user != null)
            {
                db.users.Remove(user);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public IList<Person> GetUsers()

        {
            using var db = new NorthwindContext();
            return db.users
                .ToList();
        }
        public Person? GetUser(string username)
        {
            using var db = new NorthwindContext();
            if (username != null)
            {
                return db.users.Find(username);
            }
        }
        public bool UpdateUser(User user)
        {
            using var db = new NorthwindContext();
            var dbUser = db.users.Find(user.username);
            if (dbUser == null) return false;
            dbUser.username = user.username;
            dbUser.password = user.password;
            db.SaveChanges();
            return true;
        }
    }
}
