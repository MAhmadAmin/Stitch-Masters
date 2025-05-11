using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Address
    {
        // Backing Fields
        private readonly int _addressID;
        private string _addressName;
        private string _houseNumber;
        private string _streetNumber;
        private string _city;
        private string _country;
        private int _zipCode;

        #region Getter Setter Start --------------------------------------------
        public int AddressID
        {
            get { return _addressID; }
        }
        public string AddressName
        {
            get { return _addressName; }
            set { _addressName = value; }
        }
        public string HouseNumber
        {
            get { return _houseNumber; }
            set { _houseNumber = value; }
        }
        public string StreetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Country
        {
            get { return _country; }
            set{ _country = value; }
        }
        public int ZipCode
        {
            get { return _zipCode; }
            set {_zipCode = value; }
        }
        #endregion Getter Setter End --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public Address(int addressID, string addressName, string houseNumber, string streetNumber, string city, string country, int zipCode)
        {   // Full Oaram Constructor
            if (IsValid.DBID(addressID))
            {
            _addressID = addressID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Address ID");
            }
            AddressName = addressName;
            HouseNumber = houseNumber;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
        public Address(string addressName, string houseNumber, string streetNumber, string city, string country, int zipCode)
        {   // Full Oaram Constructor
            AddressName = addressName;
            HouseNumber = houseNumber;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
        public Address(Address other)
        {  // Copy Constructor
            if (other is null)
            {
                //throw new ArgumentNullException("Invalid Request");
                //throw new ArgumentNullException(nameof(other));
            }
            else
            {
                if (IsValid.DBID(other.AddressID))
                {
                    _addressID = other.AddressID; // must use backing field as it's readonly
                }
                else
                {
                    throw new InvalidOperationException("Invalid Address ID");
                }
                AddressName = other.AddressName;
                HouseNumber = other.HouseNumber;
                StreetNumber = other.StreetNumber;
                City = other.City;
                Country = other.Country;
                ZipCode = other.ZipCode;
            }
        }
        #endregion Constructors End ----------------------------------------------
    }
}
