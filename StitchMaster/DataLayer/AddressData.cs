using StitchMaster.BusinessLogic;

namespace StitchMaster.DataLayer
{
    public class AddressData
    {
        static private AddressData _addressData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private AddressData() { }

        static public AddressData Instance
        {
            get
            {
                if (_addressData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_addressData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _addressData = new AddressData();
                        }
                    }
                }
                return _addressData;
            }
        }
    }
}
