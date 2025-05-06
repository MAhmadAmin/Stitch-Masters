namespace StitchMaster.DataLayer
{
    public class FabricProductData
    {
        static private FabricProductData _fabricProductData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricProductData() { }

        static public FabricProductData Instance
        {
            get
            {
                if (_fabricProductData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_fabricProductData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _fabricProductData = new FabricProductData();
                        }
                    }
                }
                return _fabricProductData;
            }
        }
    }
}
