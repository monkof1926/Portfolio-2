using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IUserDataService
    {
        IList<User> GetUsers();
        User? GetUsers(string username);
        void CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string username);

        User CreateUser(string username, string password = null, string salt = null);


    }
}
