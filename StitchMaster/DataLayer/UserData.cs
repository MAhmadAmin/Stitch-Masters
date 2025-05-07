using System.Data;
using StitchMaster.BusinessLogic;

namespace StitchMaster.DataLayer
{
    static public class UserData
    {
        static public bool IsValidUser(string email, string password)
        {
            DataTable dt = DatabaseHelper.Instance.GetDataTable($"SELECT * FROM users WHERE email='{email}' AND password_hash='{password}'");
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
    }
}
