using System.Diagnostics.Metrics;
using System.Net;
using Org.BouncyCastle.Tls.Crypto;
using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Customer : User
    {
        private readonly int _customerID;
        private string _gender;
        private DateOnly _dOB;
        private List<Address> _myAddresses = new List<Address>();
        //private List<Measurement> myMeasurements = new Lis

        List<FabricPurchased> _myPurchasedFabrics = new List<FabricPurchased>();

        #region Lists Getter Setter & Methods Start ----------------------------
        List<FabricPurchased> MyPurchaseFabrics
        {
            get { return new List<FabricPurchased>(_myPurchasedFabrics); }
            set { _myPurchasedFabrics = new List<FabricPurchased>(value); }
        }
        List<Address> MyAddresses
        {
            get { return new List<Address>(_myAddresses); }
            set { _myAddresses = new List<Address>(value); }
        }
        #endregion Lists Getter Setter & Methods End ----------------------------

        #region Getter Setter Start --------------------------------------------
        public int CustomerID
        {
            get { return _customerID; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public DateOnly DOB
            {
            get { return new DateOnly(_dOB.Year,_dOB.Month,_dOB.Day); }
            set { _dOB = new DateOnly(value.Year, value.Month, value.Day); }
            }
        #endregion 

        #region Constructors Start ----------------------------------------------
        public Customer(int customerID, string gender, DateOnly dOB, List<Address> myAddresses, int userID, string username, string name, string email, string hashed_Password, string profile_Img_URL, DateTime accountCreationDate, UserRole userRole): base( userID,  username,  name,  email,  hashed_Password,  profile_Img_URL,  accountCreationDate,  userRole)
        {  // Full Param Constructor
            if(IsValid.DBID(customerID))
            {
            this._customerID = customerID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Customer ID");
            }
            this.Gender = gender;
            this.DOB = dOB;
            this.MyAddresses = myAddresses;

        }
        public Customer(Customer c):base (c)
        {  // Full Param Constructor
            if (IsValid.DBID(c.CustomerID))
            {
                this._customerID = c.CustomerID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Customer ID");
            }
            this.Gender = c.Gender;
            this.DOB = c.DOB;
            this.MyAddresses = c.MyAddresses;

        }
        #endregion 

    }
}
