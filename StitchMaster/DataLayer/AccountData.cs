using StitchMaster.Interfaces;
using StitchMaster.BusinessLogic;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using MySql.Data.MySqlClient;
using StitchMaster.HelperClasses;
namespace StitchMaster.DataLayer
{
    public class AccountData : IAccountData
    {
        static private IAccountData _accountData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private AccountData() { }

        static public IAccountData Instance
        {
            get
            {
                if (_accountData == null) // 1st Check
                {
                    lock (_lock)
                    {
                        if (_accountData == null) // 2nd Check
                        {
                            _accountData = new AccountData();
                        }
                    }
                }
                return _accountData;
            }
        }
        public bool StoreObject(Account account)
        {
            return true;
        }
        public bool DeleteObject(Account account)
        {
            return true;
        }
        public bool UpdateObject(Account account)
        {
            string query = $"UPDATE account SET balance = {account.Balance} WHERE account_id = {account.AccountID}";

            int result = DatabaseHelper.Instance.ExecuteQuery(query);
            return true;
        }

        public Account? GetAccountByUserId(int userId)
        {
            string query = $"SELECT * FROM account WHERE user_id = {userId}";

            MySqlDataReader reader = DatabaseHelper.Instance.getDataReader(query);
            Account account = null;

            if (reader.Read())
            {
                account = new Account
                (
                    reader.GetInt32(reader.GetOrdinal("account_id")),
                    reader.GetInt32(reader.GetOrdinal("balance"))
                );
            }

            reader.Close();
            return account;
        }

        public List<Account> GetAllObjects()
        {
            List<Account> allAccounts = new List<Account>();
            // DB Code
            return allAccounts;
        }


    }
}
