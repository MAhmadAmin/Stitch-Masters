using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
namespace StitchMaster.DataLayer
{
    public class FabricPurchasedData
    {
        static private FabricPurchasedData _fabricPurchasedData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricPurchasedData() { }

        static public FabricPurchasedData Instance
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


    }
}
