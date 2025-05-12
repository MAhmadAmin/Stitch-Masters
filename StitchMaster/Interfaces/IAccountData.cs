using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IAccountData
    {
        public bool StoreObject(Account account);
        public bool DeleteObject(Account account);
        public bool UpdateObject(Account account);

        public Account? GetAccountByUserId(int userid);
        public List<Account> GetAllObjects();


    }
}
