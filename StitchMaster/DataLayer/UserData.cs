using StitchMaster.BusinessLogic;

namespace StitchMaster
{
    public class UserData
    {
        static private UserData _userData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private UserData(){ }

        static public UserData Instance
        {
            get  
            {
                if (_userData == null) // 1st Check
                {
                    lock (_lock)
                    {
                        if (_userData == null) // 2nd Check
                        {
                            _userData = new UserData();
                        }
                    }
                }
                return _userData;
            }
        }
        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            return allUsers;
        }
    }
}
