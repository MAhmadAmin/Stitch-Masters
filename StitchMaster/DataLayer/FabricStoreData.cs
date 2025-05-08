using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    public class FabricStoreData
    {
        static private FabricStoreData _fabricStoreData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricStoreData() { }

        static public FabricStoreData Instance
        {
            get
            {
                if (_fabricStoreData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_fabricStoreData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _fabricStoreData = new FabricStoreData();
                        }
                    }
                }
                return _fabricStoreData;
            }
        }

        public int StoreFabricStore(FabricStore store)
        {
            int userTuple, storeTuple;

            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{store.Username}', '{store.FullName}', '{store.Email}', '{store.Password}', null, Now(), '{store.UserRole.RoleID}')";
            userTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            User u = UserData.GetUserByEmail(store.Email); //Getting user to get the user id from Database;

            query = $"INSERT INTO Fabric_Store (description, user_id) VALUES (null, {u.UserID})";
            storeTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            if (userTuple == 1 && storeTuple == 1)
                return 1;
            else
                return 0;
        }

    }
}
