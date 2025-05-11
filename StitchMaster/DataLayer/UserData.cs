using System.Data;
using Org.BouncyCastle.Security;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
     public class UserData:IUserData
    {
        static private IUserData _userData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private UserData() { }

        static public IUserData Instance
        {
            get
            {
                if (_userData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_userData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _userData = new UserData();
                        }
                    }
                }
                return _userData;
            }
        }
        public bool StoreObject(User user)
        {
            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{user.Username}', '{user.FullName}', '{user.Email}', '{user.Password}', null, Now(), '{user.UserRole.RoleID}')";
            return DatabaseHelper.Instance.ExecuteQuery(query) > 0;
        }
        public bool DeleteObject(User user)
        {
            return true;
        }
        public bool UpdateObject(User user)
        {
            return true;
        }
        public List<User> GetAllObjects()
        {
            List<User> allUsers = new List<User>();
            return allUsers;
        }
    
       
         public bool IsValidUser(string email, string password)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE email='{email}' AND hashed_password='{password}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
         public bool UsernameExists(string username)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE username='{username}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
         public bool EmailExists(string email)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE email='{email}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
         public User GetUserByEmail(string email)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE email='{email}'");
            if (dt.Rows.Count == 1)
            {
                return FillUser(dt);
            }
            else
            {
                return null;
            }

        }
         private User FillUser(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {

                DataRow dr = dt.Rows[0];
                UserRole ur = UserRoleData.Instance.GetRoleByID(Convert.ToInt32(dr["role_id"]));
                int a = 5;
                return new User(Convert.ToInt32(dr["user_id"]), dr["username"].ToString(), dr["name"].ToString(), dr["email"].ToString(), dr["hashed_password"].ToString(), dr["profile_img_url"].ToString(), Convert.ToDateTime(dr["created_at"]), ur);
            }
            else
            {
                return null;
            }
        }
    }
}
