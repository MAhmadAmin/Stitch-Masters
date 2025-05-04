using System.Drawing;
using System.Runtime.InteropServices;
using ZstdSharp.Unsafe;

namespace StitchMaster.BusinessLogic
{
    public class FabricProduct
    {
        // Backing Fields
        private int _fabricProductID;
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
            set { _fabricProductID = value; }
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
            FabricProductID = fabricProductID;
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
        #endregion Constructors End ----------------------------------------------
    }
}
