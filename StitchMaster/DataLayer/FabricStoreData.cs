using MySql.Data.MySqlClient;
using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster;
using System.Data;

using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class FabricStoreData:IFabricStoreData
    {
        static private IFabricStoreData _fabricStoreData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricStoreData() { }

        static public IFabricStoreData Instance
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

        public int GetStoreUserId(int storeid)
        {
            string query = $"SELECT user_id FROM fabric_store WHERE store_id = {storeid}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["user_id"]);
            }

            throw new InvalidOperationException("user not found or store_id is invalid.");
        }
        

        public bool StoreObject(FabricStore fabricStore)
        {
            int userTuple, storeTuple;

            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{fabricStore.Username}', '{fabricStore.FullName}', '{fabricStore.Email}', '{fabricStore.Password}', null, Now(), '{fabricStore.UserRole.RoleID}')";
            userTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            User u = UserData.Instance.GetUserByEmail(fabricStore.Email); //Getting user to get the user id from Database;

            query = $"INSERT INTO Fabric_Store (description, user_id) VALUES (null, {u.UserID})";
            storeTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            if (userTuple == 1 && storeTuple == 1)
                return true;
            else
                return false;
        }
        public bool DeleteObject(FabricStore fabricStore)
        {
            return true;
        }
        public bool UpdateObject(FabricStore fabricStore)
        {
            return true;
        }
        public List<FabricStore> GetAllObjects()
        {
            List<FabricStore> allStores = new List<FabricStore>();
            string sql = $"Select * from fabric_store as f natural join users as u inner join lookup as l on u.role_id = l.lookup_id left join address as a on f.user_id = a.user_id;";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(sql);
            foreach(DataRow dr in dt.Rows)
            {
                FabricStore store = new FabricStore(int.Parse(dr["store_id"].ToString()), dr["description"].ToString(),new Address(1,"","","","","",0),int.Parse( dr["user_id"].ToString()), dr["username"].ToString(), dr["name"].ToString(), dr["email"].ToString(), dr["hashed_password"].ToString(), dr["profile_img_url"].ToString(),DateTime.Parse(dr["created_at"].ToString()), new UserRole(int.Parse(dr["lookup_id"].ToString()), dr["value"].ToString())  );
                allStores.Add(store);
            }
            return allStores;
        }

    }
}
