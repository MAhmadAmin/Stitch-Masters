namespace StitchMaster.DataLayer
{
    public class TailorGigData
    {
        static private TailorGigData _tailorGigData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorGigData() { }

        static public TailorGigData Instance
        {
            get
            {
                if (_tailorGigData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_tailorGigData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _tailorGigData = new TailorGigData();
                        }
                    }
                }
                return _tailorGigData;
            }
        }
    }
}
