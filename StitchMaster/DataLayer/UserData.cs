using System.Data;
using Org.BouncyCastle.Security;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    static public class UserData
    {
        static public int StoreUser(User user)
        {
            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{user.Username}', '{user.FullName}', '{user.Email}', '{user.Password}', null, Now(), '{user.UserRole.RoleID}')";
            return DatabaseHelper.Instance.ExecuteQuery(query);
        }
        static public bool IsValidUser(string email, string password)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE email='{email}' AND hashed_password='{password}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
        static public bool UsernameExists(string username)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE username='{username}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
        static public bool EmailExists(string email)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE email='{email}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
        static public User GetUserByEmail(string email)
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

        static public User GetUserById(int id)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE user_id='{id}'");
            if (dt.Rows.Count == 1)
            {
                return FillUser(dt);
            }
            else
            {
                return null;
            }

        }
        static private User FillUser(DataTable dt)
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
