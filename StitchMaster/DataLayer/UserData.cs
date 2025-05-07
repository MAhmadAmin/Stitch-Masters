using System.Data;
using StitchMaster.BusinessLogic;

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
    }
}
