using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IAddressData
    {
        public bool StoreObject(Address address);
        public bool DeleteObject(Address address);
        public bool UpdateObject(Address address);
        public List<Address> GetAllObjects();
    }
}
