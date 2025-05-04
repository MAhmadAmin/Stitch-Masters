namespace StitchMaster.BusinessLogic
{
    public class Address
    {
        private int _addressID;
        private string _addressName;
        private string _houseNumber;
        private string _streetNumber;
        private string _city;
        private string _country;
        private int _zipCode;

        public int AddressID
        {
            get { return _addressID; }
            set { _addressID = value; }
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

        public Address(int addressID, string addressName, string houseNumber, string streetNumber, string city, string country, int zipCode)
        {
            AddressID = addressID;
            AddressName = addressName;
            HouseNumber = houseNumber;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
