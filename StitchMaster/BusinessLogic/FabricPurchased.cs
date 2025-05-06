namespace StitchMaster.BusinessLogic
{
    public class FabricPurchased
    {
        private readonly int _fabricPurchasedID;
        private FabricProduct _fabricProduct;
        private int _length;
        private int _totalPrice;
        private bool _inHold;

        #region Getter Setter Start --------------------------------------------
        public int FabricPurchasedID 
        {
            get { return _fabricPurchasedID; }
        }
        public FabricProduct FabricProduct 
        {
            get { return new FabricProduct(_fabricProduct); } 
            set { _fabricProduct = new FabricProduct( value); }
        }
        public int Length 
        {
            get { return _length; } 
            set { _length = value; }
        }

        public int TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        public bool InHold
        {
            get { return _inHold; }
            set { _inHold = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public FabricPurchased(int fabricPurchasedID, FabricProduct fabricProduct, int length, int totalPrice, bool inHold)
        {
            _fabricPurchasedID = fabricPurchasedID;
            FabricProduct = fabricProduct;
            Length = length;
            TotalPrice = totalPrice;
            InHold = inHold;
        }
        public FabricPurchased(FabricPurchased fP)
        {
            _fabricPurchasedID = fP.FabricPurchasedID;
            FabricProduct = fP.FabricProduct;
            Length = fP.Length;
            TotalPrice = fP.TotalPrice;
            InHold = fP.InHold;
        }
        #endregion Constructors End ----------------------------------------------
    }
}
