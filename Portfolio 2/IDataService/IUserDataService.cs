using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IUserDataService
    {
        IList<User> GetUsers();
        User? GetUser(string username);
        void CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string username);

    }
}
