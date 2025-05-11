using StitchMaster.BusinessLogic;

using StitchMaster.HelperClasses;

using StitchMaster.Interfaces;


namespace StitchMaster.DataLayer
{
    public class FabricPurchasedData : IFabricPurchasedData
    {
        static private IFabricPurchasedData _fabricPurchasedData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricPurchasedData() { }

        static public IFabricPurchasedData Instance
        {
            get
            {
                if (_fabricPurchasedData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_fabricPurchasedData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _fabricPurchasedData = new FabricPurchasedData();
                        }
                    }
                }
                return _fabricPurchasedData;
            }
        }

        public int StoreFabricPurchased(FabricPurchased fabricPurchasedData, int tailorid)
        {
            string query = $"INSERT INTO fabric_purchased (fabric_id, buyer_id, length, total_price) " +
                           $"VALUES ('{fabricPurchasedData.FabricProduct.FabricProductID}', '{tailorid}', '{fabricPurchasedData.Length}', '{fabricPurchasedData.TotalPrice}')";
            return DatabaseHelper.Instance.ExecuteQuery(query);
        }

        public FabricPurchased GetFabricPurchasedByID(int ID)
        {
            string query = $"SELECT * FROM fabric_purchased WHERE fabric_purchased_id = {ID}";
            var reader = DatabaseHelper.Instance.getDataReader(query);
            if (reader.Read())
            {
                int fabricPurchasedID = Convert.ToInt32(reader["fabric_purchased_id"]);
                int fabricProductID = Convert.ToInt32(reader["fabric_id"]);
                int buyerID = Convert.ToInt32(reader["buyer_id"]);
                int length = Convert.ToInt32(reader["length"]);
                int totalPrice = Convert.ToInt32(reader["total_price"]);
                FabricProduct fabricProduct = FabricProductData.Instance.GetProductById(fabricProductID);
                FabricPurchased fabricPurchased = new FabricPurchased(fabricPurchasedID, fabricProduct, length, totalPrice, false);
                return fabricPurchased;
            }
            return null;
        }



        public bool StoreObject(Customer customer, FabricPurchased fabricPurchased)
        {
            return true;
        }
        public bool DeleteObject(FabricPurchased fabricPurchased)
        {
            return true;
        }
        public bool UpdateObject(FabricPurchased fabricPurchased)
        {
            return true;
        }
        public List<FabricPurchased> GetAllObjects()
        {
            List<FabricPurchased> allFabricPurchasedItems = new List<FabricPurchased>();
            return allFabricPurchasedItems;
        }

    }
}
