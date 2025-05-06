using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class FabricStore : User
    {
        // Backing Fields
        private readonly int _fabricStoreID;
        private string _fabricStoreDescription;
        private Address _fabricStoreAddress;

        private List<FabricProduct> _myFabricProducts = new List<FabricProduct>();
        
        #region Getter Setter Start --------------------------------------------
        public int FabricStoreID
        {
            get { return _fabricStoreID; } 
        }
        public string FabricStoreDescription
        {
            get { return _fabricStoreDescription; }
            set { _fabricStoreDescription = value; }
        }
        public Address FabricStoreAddress
        {
            get { return new Address( _fabricStoreAddress); }
            set { _fabricStoreAddress = new Address(value); }
        }
        List<FabricProduct> MyFabricProducts
        {
            get { return new List<FabricProduct>(_myFabricProducts); }
            set { _myFabricProducts = new List<FabricProduct> (value); }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public FabricStore(int fabricStoreID, string fabricStoreDescription, Address fabricStoreAddress, int userID, string username, string name, string email, string hashed_Password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole) : base(userID, username, name, email, hashed_Password, profile_Img_URL, accountCreationDate, userRole)
        {
            if (IsValid.DBID(fabricStoreID))
            {
                _fabricStoreID = fabricStoreID;
            }
            else
            {
                throw new ArgumentException("Invalid Facric Store ID");
            }
            FabricStoreDescription = fabricStoreDescription;
            FabricStoreAddress = fabricStoreAddress;
            // Here we have not Set  (Laoded) the ProductList
        }
        #endregion Constructors Start ----------------------------------------------
    }
}
