namespace StitchMaster.BusinessLogic
{
    public class FabricStore : User
    {
        private int _fabricStoreID;
        private string _fabricStoreDescription;
        private Address _fabricStoreAddress;

        public int FabricStoreID
        {
            get { return _fabricStoreID; } 
            set { _fabricStoreID = value; }
        }
        public string FabricStoreDescription
        {
            get { return _fabricStoreDescription; }
            set { _fabricStoreDescription = value; }
        }
        public Address FabricStoreAddress
        {
            get { return _fabricStoreAddress; }
            set { _fabricStoreAddress = value; }
        }
        public FabricStore(int fabricStoreID, string fabricStoreDescription, Address fabricStoreAddress, int userID, string username, string name, string email, string hashed_Password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole) : base(userID, username, name, email, hashed_Password, profile_Img_URL, accountCreationDate, userRole)
        {
            FabricStoreID = fabricStoreID;
            FabricStoreDescription = fabricStoreDescription;
            FabricStoreAddress = fabricStoreAddress;
        }
    }
}
