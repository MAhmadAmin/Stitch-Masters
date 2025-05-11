using System.Data;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    public class TailorData
    {
        static private TailorData _tailorData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorData() { }

        static public TailorData Instance
        {
            get
            {
                if (_tailorData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_tailorData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _tailorData = new TailorData();
                        }
                    }
                }
                return _tailorData;
            }
        }

        public int StoreTailor(Tailor tailor)
        {
            int userTuple, tailorTuple;

            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{tailor.Username}', '{tailor.FullName}', '{tailor.Email}', '{tailor.Password}', null, Now(), '{tailor.UserRole.RoleID}')";
            userTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            User u = UserData.GetUserByEmail(tailor.Email); //Getting user to get the user id from Database;

            query = $"INSERT INTO Tailor (description, user_id) VALUES (null, {u.UserID})";
            tailorTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            if (userTuple == 1 && tailorTuple == 1)
                return 1;
            else
                return 0;
        }

        public Tailor GetTailorByEmail(string email)
        {
            string query = $"SELECT * FROM Users U INNER JOIN Tailor T ON U.user_id = T.user_id WHERE email = '{email}';";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return FillTailor(dt);
        }

        public Tailor GetTailorByID(int ID)
        {
            string query = $"SELECT * FROM Users U INNER JOIN Tailor T ON U.user_id = T.user_id WHERE tailor_id = '{ID}'";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(query);
            return FillTailor(dt);
        }

        private Tailor FillTailor(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {

                DataRow dr = dt.Rows[0];
                int tailorID = Convert.ToInt32(dr["tailor_id"]);
                string description = dr["description"].ToString();
                UserRole ur = UserRoleData.Instance.GetUserRoleByEmail(dr["email"].ToString());
                Tailor tailor = new Tailor(tailorID, description, Convert.ToInt32(dr["user_id"]), dr["username"].ToString(), dr["name"].ToString(), dr["email"].ToString(), dr["hashed_password"].ToString(), dr["profile_img_url"].ToString(), Convert.ToDateTime(dr["created_at"]), ur);
                return tailor;
            }
            else
                return null;
        }
    }
}
