using System.Data;
using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IUserData
    {
        public bool StoreObject(User user);
        public bool DeleteObject(User user);
        public bool UpdateObject(User user);
        public List<User> GetAllObjects();
        public bool IsValidUser(string email, string password);
        public bool UsernameExists(string username);
        public bool EmailExists(string email);
        public User GetUserByEmail(string email);
        public User GetUserById(int id);
    }
}
