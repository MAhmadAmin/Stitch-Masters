using StitchMaster.BusinessLogic;
using StitchMaster.HelperClasses;

namespace StitchMaster.DataLayer
{
    public class FabricProductData
    {
        static private FabricProductData _fabricProductData;
        static readonly private object _lock = new object();  // i make this to Avoid Lazy Laoding
        private FabricProductData() { }

        static public FabricProductData Instance
        {
            get
            {
                if (_fabricProductData == null) // 1st Check (Multiple Threads Can Execute)
                {
                    lock (_lock)
                    {
                        if (_fabricProductData == null) // 2nd Check  (Only Single Thread Can Execute)
                        {
                            _fabricProductData = new FabricProductData();
                        }
                    }
                }
                return _fabricProductData;
            }
        }
        public int AddObject(FabricStore Store,FabricProduct Product)
        {
            
            string query = $"INSERT INTO Fabric_product (`store_id`, `title`,`description`,`color_id`, `material`,`gender`, `price_per_meter`,`in_stock_qty`,`image_url`) Values ('{Store.FabricStoreID}', '{Product.FabricProductTitle}', '{Product.FabricProductDescription}', '{Product.FabricColor.ColorID}', '{Product.FabricMaterial}', '{Product.Gender}', '{Product.PricePerMeter}','{Product.StockQuantity}', '{Product.ImageURl}')";
            return DatabaseHelper.Instance.ExecuteQuery(query);
        }
    }
    

}
