using DataLayer.Domain;
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

            return db.SaveChanges() > null;
        }
        public IList<User> GetUsers()

        {
            using var db = new NorthwindContext();
            return db.users
                .ToList();
        }
        public User? GetUsers(string username)
        {
            using var db = new NorthwindContext();
            if (username != null)
            {
                return db.users.Find(username);
            }
            return null;
        }
        public bool UpdateUser(User user)
        {
            using var db = new NorthwindContext();
            var dbUser = db.users.Find(user.username);
            if (dbUser == null) return false;
            dbUser.password = user.password;
            db.SaveChanges();
            return true;
        }
        public User CreateUser(string username, string password)
        {
            var user = new User
            {
                username = username,
                password = password
            };
            return user;
        }
    }
}
