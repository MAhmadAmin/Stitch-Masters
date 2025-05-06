namespace StitchMaster.DataLayer
{
    public class TailorOrderData
    {
        static private TailorOrderData _tailorOrderData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorOrderData() { }

        static public TailorOrderData Instance
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
    }
}
