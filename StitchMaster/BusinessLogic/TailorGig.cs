using StitchMaster.HelperClasses;
using ZstdSharp.Unsafe;

namespace StitchMaster.BusinessLogic
{
    public class TailorGig
    {
        private readonly int _gigID;
        private string _gigTitle;
        private string _gigDescription;
        private Category _gigCategory;
        private int _gigPrice;
        private int _gigDeliveryDays;
        private double _gigRating;
        private string _imageURL;

        #region Getter Setter Start --------------------------------------------
       

        public int GigID
        {
            get { return _gigID; }
        }
        public string GigTitle
        {
            get { return _gigTitle; }
            set { _gigTitle = value; }
        }
        public string GigDescription
        {
            get { return _gigDescription; }
            set { _gigDescription = value; }
        }
        public int GigDeliveryDays
        {
            get { return _gigDeliveryDays; }
            set { _gigDeliveryDays = value; }
        }
        public Category GigCategory
        {
            get { return new Category(_gigCategory); }
            set { _gigCategory = new Category(value); }
        }
        public int GigPrice
        {
            get { return _gigPrice; }
            set { _gigPrice = value; }
        }
        public double GigRating
        {
            get { return _gigRating; }
            set { _gigRating = value; }
        }
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public TailorGig(int gigID, string gigTitle, string gigDescription, Category gigCategory, int gigPrice, int gigDeliveryDays, double gigRating, string imageURLs)
        {
            if (IsValid.DBID(gigID))
            {
                _gigID = gigID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Gig ID");
            }
            GigTitle = gigTitle;
            GigDescription = gigDescription;
            GigCategory = gigCategory;
            GigPrice = gigPrice;
            GigDeliveryDays = gigDeliveryDays;
            GigRating = gigRating;
            ImageURL = imageURLs;    
            
        }

        public TailorGig(string gigTitle, string gigDescription, Category gigCategory, int gigPrice, int gigDeliveryDays, string imageURL)
        {
            GigTitle = gigTitle;
            GigDescription = gigDescription;
            GigCategory = gigCategory;
            GigPrice = gigPrice;
            GigDeliveryDays = gigDeliveryDays;
            ImageURL = imageURL;

        }
        #endregion Constructors Start ----------------------------------------------
    }

}
