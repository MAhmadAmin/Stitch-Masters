using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class TailorOrderData:ITailorOrderData
    {
        static private ITailorOrderData _tailorOrderData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorOrderData() { }

        static public ITailorOrderData Instance
        {
            get
            {
                if (_tailorOrderData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_tailorOrderData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _tailorOrderData = new TailorOrderData();
                        }
                    }
                }
                return _tailorOrderData;
            }
        }
        public bool StoreObject(Tailor tailor, TailorOrder tailorOrder)
        {
            return true;
        }
        public bool DeleteObject(TailorOrder tailorOrder)
        {
            return true;
        }
        public bool UpdateObject(TailorOrder tailorOrder)
        {
            return true;
        }
        public List<TailorOrder> GetAllObjects()
        {
            List<TailorOrder> allTailorOrders = new List<TailorOrder>();
            return allTailorOrders;
        }

    }
}
