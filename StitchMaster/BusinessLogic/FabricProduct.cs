using System.Drawing;
using System.Runtime.InteropServices;
using StitchMaster.HelperClasses;
using ZstdSharp.Unsafe;

namespace StitchMaster.BusinessLogic
{
    public class FabricProduct
    {
        // Backing Fields
        private readonly int _fabricProductID;
        private string _fabricProductTitle;
        private string _fabricProductDescription;
        private FabricColor _fabricColor;
        private string _fabricMaterial;
        private string _gender;
        private int _pricePerMeter;
        private int _stockQuantity;
        private int _minStockQuantity;
        private List<string> _imageURls = new List<string>();

        #region Getter Setter Start --------------------------------------------
        
        
        public int FabricProductID
        {
            get { return _fabricProductID; }
        }
        public string FabricProductTitle
        {
            get { return _fabricProductTitle; }
            set { _fabricProductTitle = value; }
        }

        public string FabricProductDescription
        {
            get { return _fabricProductDescription; }
            set { _fabricProductDescription = value; }
        }

        public FabricColor FabricColor
        {
            get { return new FabricColor(_fabricColor); }
            set { _fabricColor = new FabricColor(value); }
        }

        public string FabricMaterial
        {
            get { return _fabricMaterial; }
            set { _fabricMaterial = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int PricePerMeter
        {
            get { return _pricePerMeter; }
            set { _pricePerMeter = value; }
        }

        public int StockQuantity
        {
            get { return _stockQuantity; }
            set { _stockQuantity = value; }
        }

        public int MinStockQuantity
        {
            get { return _minStockQuantity; }
            set { _minStockQuantity = value; }
        }
        public List<string> ImageURls
        {
            get { return new List<string>(_imageURls); }
            set { _imageURls = new List<string>(value); }
        }

        #endregion Getter Setter End --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public FabricProduct(int fabricProductID,string fabricProductTitle,string fabricProductDescription,FabricColor fabricColor,string fabricMaterial,string gender,int pricePerMeter,int stockQuantity,int minStockQuantity,List<string> imageURls)
        {
            if(IsValid.DBID(fabricProductID))
            {
                _fabricProductID=fabricProductID;
            }
            else
            {
                throw new ArgumentException("Invalid Fabric Product ID");
            }
            FabricProductTitle = fabricProductTitle;
            FabricProductDescription = fabricProductDescription;
            FabricColor = fabricColor;
            FabricMaterial = fabricMaterial;
            Gender = gender;
            PricePerMeter = pricePerMeter;
            StockQuantity = stockQuantity;
            MinStockQuantity = minStockQuantity;
            ImageURls = imageURls;   // A New Copy of imageURL List is Automatically made inside the Setter of This ImageURLs List to Encapsulate
        }
        public FabricProduct(FabricProduct fP)
        {
            if (IsValid.DBID(fP.FabricProductID))
            {
                _fabricProductID = fP.FabricProductID;
            }
            else
            {
                throw new ArgumentException("Invalid Fabric Product ID");
            }
            FabricProductTitle = fP.FabricProductTitle;
            FabricProductDescription = fP.FabricProductDescription;
            FabricColor = fP.FabricColor;
            FabricMaterial = fP.FabricMaterial;
            Gender = fP.Gender;
            PricePerMeter = fP.PricePerMeter;
            StockQuantity = fP.StockQuantity;
            MinStockQuantity = fP.MinStockQuantity;
            ImageURls = fP.ImageURls;   // A New Copy of imageURL List is Automatically made inside the Setter of This ImageURLs List to Encapsulate
        }
        #endregion Constructors End ----------------------------------------------
    }
}
