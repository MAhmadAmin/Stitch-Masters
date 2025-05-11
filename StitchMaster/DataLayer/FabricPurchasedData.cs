using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class FabricPurchasedData : IFabricPurchasedData
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
