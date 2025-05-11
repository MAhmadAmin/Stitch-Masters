using StitchMaster.BusinessLogic;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class AddressData :IAddressData
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
        public bool StoreObject(Address address)
        {
            return true;
        }
        public bool DeleteObject(Address address)
        {
            return true;
        }
        public bool UpdateObject(Address address)
        {
            return true;
        }
        public List<Address> GetAllObjects()
        {
            List<Address> allAddress = new List<Address>();

            //Db Code
            return allAddress;
        }
    }
}
