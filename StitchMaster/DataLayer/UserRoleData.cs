using System.Data;
using StitchMaster.BusinessLogic;

namespace StitchMaster.DataLayer
{
    public class UserRoleData
    {
        static private UserRoleData _userRoleData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private UserRoleData() { }

        static public UserRoleData Instance
        {
            get
            {
                if (_userRoleData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_userRoleData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _userRoleData = new UserRoleData();
                        }
                    }
                }
                return _userRoleData;
            }
        }

        public UserRole GetUserRoleByEmail(string email)
        {
            string query = $"SELECT R.role_id, R.role_name FROM Users U INNER JOIN Roles R ON U.role_id = R.role_id WHERE email = '{email}';";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count == 1)
            {
                return FillData(dt);
            }
            else
            {
                throw new Exception("User role not found for the provided email.");
            }
        }

        public string GetRoleNameByID(int roleId)
        {
            string query = $"SELECT role_name FROM Roles WHERE role_id = {roleId};";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["role_name"].ToString();
            }
            else
            {
                throw new Exception("Role not found for the provided ID.");
            }
        }
        public int GetRoleIDByName(string roleName)
        {
            string query = $"SELECT role_id FROM Roles WHERE role_name = '{roleName}';";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count == 1)
            {
                return Convert.ToInt32(dt.Rows[0]["role_id"]);
            }
            else
            {
                throw new Exception("Role not found for the provided name.");
            }
        }
        public UserRole GetRoleByName(string roleName)
        {
            string query = $"SELECT role_id, role_name FROM Roles WHERE role_name = '{roleName}';";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count == 1)
            {
                return FillData(dt);
            }
            else
            {
                throw new Exception("Role not found for the provided name.");
            }
        }

        private UserRole FillData(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {
                int roleId = Convert.ToInt32(dt.Rows[0]["role_id"]);
                string roleName = dt.Rows[0]["role_name"].ToString();
                return new UserRole(roleId, roleName);
            }
            else
            {
                return null;
            }
        }
    }
}
