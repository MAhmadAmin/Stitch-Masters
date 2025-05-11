using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface ICustomerData
    {
        public bool StoreObject(Customer customer);
        public bool DeleteObject(Customer customer);
        public bool UpdateObject(Customer customer);
        public List<Customer> GetAllObjects();
        public Customer GetCustomerByUserId(int userId);

        public Customer GetCustomerByID(int ID);
    }
}
