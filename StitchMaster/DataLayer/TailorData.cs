
﻿using System.Data;

﻿using MySql.Data.MySqlClient;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class TailorData : ITailorData
    {
        static private ITailorData _tailorData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorData() { }

        static public ITailorData Instance
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


        public bool StoreObject(Tailor tailor)
        {
            int userTuple, tailorTuple;

            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{tailor.Username}', '{tailor.FullName}', '{tailor.Email}', '{tailor.Password}', null, Now(), '{tailor.UserRole.RoleID}')";
            userTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            User u = UserData.Instance.GetUserByEmail(tailor.Email); //Getting user to get the user id from Database;

            query = $"INSERT INTO Tailor (description, user_id) VALUES (null, {u.UserID})";
            tailorTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            if (userTuple == 1 && tailorTuple == 1)
                return true;
            else
                return false;
        }
        public bool DeleteObject(Tailor tailor)
        {
            return true;
        }
        public bool UpdateObject(Tailor tailor)
        {
            return true;
        }
        public List<Tailor> GetAllObjects()
        {
            List<Tailor> allTailors = new List<Tailor>();
            return allTailors;
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
