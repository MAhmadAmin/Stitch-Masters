using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

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
            string query = $"SELECT L.lookup_id, L.value FROM Users U INNER JOIN Lookup L ON U.role_id = L.lookup_id WHERE email = '{email}';";
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
            string query = $"SELECT value FROM Lookup WHERE lookup_id = {roleId};";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["value"].ToString();
            }
            else
            {
                throw new Exception("Role not found for the provided ID.");
            }
        }
        public int GetRoleIDByName(string roleName)
        {
            string query = $"SELECT lookup_id FROM Lookup WHERE value = '{roleName}';";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            if (dt.Rows.Count == 1)
            {
                return Convert.ToInt32(dt.Rows[0]["lookup_id"]);
            }
            else
            {
                throw new Exception("Role not found for the provided name.");
            }
        }
        public UserRole GetRoleByName(string roleName)
        {
            string query = $"SELECT lookup_id, value FROM Lookup WHERE value = '{roleName}';";
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
                int roleId = Convert.ToInt32(dt.Rows[0]["lookup_id"]);
                string roleName = dt.Rows[0]["value"].ToString();
                return new UserRole(roleId, roleName);
            }
            else
            {
                return null;
            }
        }
    }
}
