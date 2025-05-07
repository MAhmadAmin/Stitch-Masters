namespace StitchMaster.DataLayer
{
    public class AccountData
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
    }
}
