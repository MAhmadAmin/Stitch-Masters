namespace StitchMaster.BusinessLogic
{
    public class Account
    {
        private readonly int _accountID;
        private float _balance;

        public int AccountID 
        {
            get { return _accountID; } 
        }
        public float Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public Account(int accountID, float balance)
        {
            if(IsValid.DBID(accountID))
            {
                _accountID = accountID;
            }
            else
            {
                throw new ArgumentException("Invalid Account ID");
            }
            Balance = balance;
        }
    }
}
