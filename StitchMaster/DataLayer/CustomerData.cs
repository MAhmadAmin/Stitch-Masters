using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;
using StitchMaster.Interfaces;

namespace StitchMaster.DataLayer
{
    public class CustomerData : ICustomerData
    {
        static private ICustomerData _customerData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private CustomerData() { }

        static public ICustomerData Instance
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


        public Customer GetCustomerByUserId(int userId)
        {
            if (!IsValid.DBID(userId))
                throw new ArgumentException("Invalid User ID");

            string query = $@"
        SELECT 
            b.buyer_id, b.gender, b.date_of_birth,
            u.user_id, u.username, u.name, u.email, u.hashed_password, u.profile_img_url, u.created_at, u.role_id
        FROM Buyer b
        INNER JOIN Users u ON b.user_id = u.user_id
        WHERE u.user_id = {userId}";

            var reader = DatabaseHelper.Instance.getDataReader(query);

            if (reader.Read())
            {
                int customerId = Convert.ToInt32(reader["buyer_id"]);
                string genderStr = reader["gender"].ToString();
                DateOnly dob = DateOnly.FromDateTime(Convert.ToDateTime(reader["date_of_birth"]));

                int userID = Convert.ToInt32(reader["user_id"]);
                string username = reader["username"].ToString();
                string fullName = reader["name"].ToString();
                string email = reader["email"].ToString();
                string password = reader["hashed_password"].ToString();
                string profileImg = reader["profile_img_url"] != DBNull.Value ? reader["profile_img_url"].ToString() : null;
                DateTime createdAt = Convert.ToDateTime(reader["created_at"]);
                int roleId = Convert.ToInt32(reader["role_id"]);

                // Assume UserRole name is not stored in Users table, you can get it if needed from Role table
                UserRole role = new UserRole(roleId, "");

                // Convert gender string to enum
                if (!Enum.TryParse(genderStr, out Customer.GenderType gender))
                    throw new InvalidOperationException("Invalid gender value from database");

                // Optional: You can fetch addresses here if needed
                List<Address> addresses = new List<Address>();
                // Example: addresses = AddressData.Instance.GetAddressesByUserId(userId);

                Customer customer = new Customer(
                    customerId,
                    gender,
                    dob,
                    addresses,
                    userID,
                    username,
                    fullName,
                    email,
                    password,
                    profileImg,
                    createdAt,
                    role
                );

                return customer;
            }

            return null; // No customer found
        }

        

        public bool StoreObject(Customer customer)
        {
            int userTuple, customerTuple;

            string query = $"INSERT INTO Users (username, name, email, hashed_password, profile_img_url, created_at, role_id) Values ('{customer.Username}', '{customer.FullName}', '{customer.Email}', '{customer.Password}', null, Now(), '{customer.UserRole.RoleID}')";
            userTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            User u = UserData.Instance.GetUserByEmail(customer.Email); //Getting user to get the user id from Database;

            query = $"INSERT INTO Buyer (gender, date_of_birth, user_id) VALUES ('{customer.Gender.ToString()}', '{customer.DOB.ToString("yyyy-MM-dd")}', {u.UserID})";
            customerTuple = DatabaseHelper.Instance.ExecuteQuery(query);

            if (userTuple == 1 && customerTuple == 1)
                return true;
            else
                return false;
        }
        public bool DeleteObject(Customer customer)
        {
            return true;
        }
        public bool UpdateObject(Customer customer)
        {
            return true;
        }
        public List<Customer> GetAllObjects()
        {
            List<Customer> allCustomer = new List<Customer>();
            return allCustomer;
        }
    }
}
