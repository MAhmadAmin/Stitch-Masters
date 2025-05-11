using System.Data;
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
        public List<FabricPurchased> GetPurchasedFabricsByInHoldStatus(Customer customer, bool inHold)
        {
            List<FabricPurchased> allInHoldFabricsForCurrentCustomer = new List<FabricPurchased>();
            string sql = $"select * from fabric_purchased as fpu inner join fabric_product as fpo  on fpu.fabric_id = fpo.fabric_id  where buyer_id = {customer.CustomerID} and inHold = {inHold};";
            DataTable dt = DatabaseHelper.Instance.GetDataTable(sql);

            List<FabricColor> allColors = FabricColorData.Instance.GetAllObjects();
            
            
            foreach(DataRow dr in dt.Rows)
            {
                FabricColor CuurentColor = allColors.Find(FP => FP.ColorID == int.Parse(dr["color_id"].ToString()));
                FabricProduct product = new FabricProduct(int.Parse(dr["fabric_id"].ToString()), dr["title"].ToString(), dr["description"].ToString(), CuurentColor, dr["material"].ToString(), Gender.StringToGenderType(dr["gender"].ToString()), int.Parse(dr["price_per_meter"].ToString()), int.Parse(dr["in_stock_qty"].ToString()),int.Parse( dr["min_stock_qty"].ToString()), dr["image_url"].ToString());
                FabricPurchased fabricPurchased = new FabricPurchased(int.Parse(dr["fabric_purchased_id"].ToString()), product, int.Parse(dr["length"].ToString()), int.Parse(dr["totalprice"].ToString()), bool.Parse(dr["inhold"].ToString()));
                allInHoldFabricsForCurrentCustomer.Add(fabricPurchased);
            }
            return allInHoldFabricsForCurrentCustomer;
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
            // Code
            return allFabricPurchasedItems;
        }

    }
}
