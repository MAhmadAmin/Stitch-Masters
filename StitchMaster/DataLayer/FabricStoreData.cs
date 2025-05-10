using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster;
using System.Data;

namespace StitchMaster
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
        public List<FabricStore> GetAllObjects()
        {
            List<FabricStore> allStores = new List<FabricStore>();
            string sql = $"Select * from fabric_store as f natural join users as u inner join lookup as l on u.role_id = l.lookup_id";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(sql);
            foreach(DataRow dr in dt.Rows)
            {
                FabricStore store = new FabricStore(int.Parse(dr["f.store_id"].ToString()), dr["f.description"].ToString(),null,int.Parse( dr["f.user_id"].ToString()), dr["u.username"].ToString(), dr["u.name"].ToString(), dr["u.email"].ToString(), dr["u.hashed_password"].ToString(), dr["u.profile_img_url"].ToString(),DateTime.Parse(dr["u.created_at"].ToString()), new UserRole(int.Parse(dr["l.lookup_id"].ToString()), dr["l.value"].ToString())  );
                allStores.Add(store);
            }
            return allStores;
        }
    }
}
