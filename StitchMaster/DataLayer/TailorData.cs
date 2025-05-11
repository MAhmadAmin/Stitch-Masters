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
    }
}
