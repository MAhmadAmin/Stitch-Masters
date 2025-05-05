using MySqlX.XDevAPI.Relational;
using System.Data;
using StitchMaster.BusinessLogic;

namespace StitchMaster.DataLayer
{
    static public class UserDL
    {
        static public User GetUser(string username, string password)
        {
            string query = $"SELECT * FROM USERS INNER JOIN Roles WHERE username = '{username}' AND password_hash = '{password}'";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            User user = FillUser(dt);
            return user;
        }

        static private User FillUser(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                //User user =
                //    new User(
                //        Convert.ToInt32(row["id"]),
                //    row["username"].ToString(),
                //    row["name"].ToString(),
                //    row["email"].ToString(),
                //    row["password"].ToString(),
                //    row["ProfilePicURL"].ToString(),
                //    Convert.ToDateTime(row["account_created"]),
                //    new UserRole(Convert.ToInt32(row["role_id"]), row["Role_Value"].ToString())
                //    );

                User user =
                    new User(
                        Convert.ToInt32(row["user_id"]),
                    row["username"].ToString(),
                    row["email"].ToString(),
                    row["password_hash"].ToString(),
                    new UserRole(Convert.ToInt32(row["role_id"]), row["role_name"].ToString())
                    );

                return user;
            }
            else
                return null;
        }
    }
}
