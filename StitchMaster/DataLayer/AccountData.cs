using StitchMaster.Interfaces;
using StitchMaster.BusinessLogic;
namespace StitchMaster.DataLayer
{
    public class AccountData : IAccountData
    {
        static private AccountData _accountData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private AccountData() { }

        static public AccountData Instance
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
            return true;
        }
        public List<Account> GetAllObjects()
        {
            List<Account> allAccounts = new List<Account>();
            // DB Code
            return allAccounts;
        }


    }
}
