namespace StitchMaster.DataLayer
{
    public class CustomerData
    {
        static private CustomerData _customerData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private CustomerData() { }

        static public CustomerData Instance
        {
            get
            {
                if (_customerData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_customerData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _customerData = new CustomerData();
                        }
                    }
                }
                return _customerData;
            }
        }
    }
}
