using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

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

        public int StoreCustomer(Customer customer)
        {
            int userTuple, customerTuple;

            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{customer.Username}', '{customer.FullName}', '{customer.Email}', '{customer.Password}', null, Now(), '{customer.UserRole.RoleID}')";
            userTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            User u = UserData.GetUserByEmail(customer.Email); //Getting user to get the user id from Database;

            query = $"INSERT INTO Buyer (gender, date_of_birth, user_id) VALUES ('{customer.Gender.ToString()}', '{customer.DOB.ToString("yyyy-MM-dd")}', {u.UserID})";
            customerTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            if (userTuple == 1 && customerTuple == 1)
                return 1;
            else
                return 0;
        }
    }
}
