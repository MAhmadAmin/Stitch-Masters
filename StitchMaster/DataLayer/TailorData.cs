namespace StitchMaster.DataLayer
{
    public class TailorData
    {
        static private TailorData _tailorData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private TailorData() { }

        static public TailorData Instance
        {
            get
            {
                if (_tailorData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_tailorData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _tailorData = new TailorData();
                        }
                    }
                }
                return _tailorData;
            }
        }
    }
}
