using MySql.Data.MySqlClient;
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

        public int GetTailorUserId(int tailorid)
        {
            string query = $"SELECT user_id FROM tailor WHERE tailor_id = {tailorid}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["user_id"]);
            }

            throw new InvalidOperationException("user not found or tailor_id is invalid.");
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
    }
}
